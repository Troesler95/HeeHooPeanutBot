using HeeHooPeanut.Discord.Api.Gateway;
using HeeHooPeanut.Discord.Api.Gateway.Events;
using HeeHooPeanut.Discord.Api.Gateway.Guilds;
using HeeHooPeanut.Discord.Interfaces.Messages;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.JsonConverters
{
    public class GatewayPayloadJsonConverter : JsonConverter<GatewayPayload>
    {
        public override bool CanConvert(Type typeToConvert) =>
            !typeToConvert.IsGenericType && typeToConvert.IsAssignableFrom(typeof(GatewayPayload));

        public override GatewayPayload Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("The reader started in an invalid state!");
            }

            // object to fill in
            GatewayPayload payload = new GatewayPayload();
            string propName = string.Empty;
            JsonDocument jsonDoc = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject && reader.CurrentDepth == 0)
                {
                    break;
                }
                else if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    propName = reader.GetString();
                }
                else
                {
                    // fields starting with an underscore should be ignored
                    // see https://discord.com/developers/docs/topics/gateway#gateways
                    if (propName.StartsWith('_') || reader.TokenType == JsonTokenType.Null)
                        continue;

                    if (reader.TokenType == JsonTokenType.Number)
                    {
                        if (propName == "op")
                        {
                            if (reader.TryGetInt32(out int opCode))
                            {
                                payload.Code = (OpCodes.Gateway)opCode;
                            }
                        }
                        else if (propName == "s")
                        {
                            if (reader.TryGetInt32(out int sequenceNum))
                            {
                                payload.SequenceNumber = sequenceNum;
                            }
                        }
                    }
                    else if (reader.TokenType == JsonTokenType.String && propName == "t")
                    {
                        payload.EventName = reader.GetString();
                    }
                    else if (reader.TokenType == JsonTokenType.StartObject && propName == "d")
                    {
                        jsonDoc = JsonDocument.ParseValue(ref reader);
                    }
                    else
                    {
                        throw new JsonException($"Unable to parse incoming payload. Could not find appropriate match for field '{propName}'.");
                    }
                }
            }

            if (jsonDoc != null)
            {
                ParseDataValue(ref reader, ref payload, jsonDoc.RootElement);
                jsonDoc?.Dispose();
            }

            return payload;
        }

        public override void Write(Utf8JsonWriter writer, GatewayPayload value, JsonSerializerOptions options)
        {
            // Gateway payload is a special case where sequence number will be sent in the 
            // data field
            if(value.Code == OpCodes.Gateway.Heartbeat && value.SequenceNumber.HasValue)
            {
                WriteHeartbeat(writer, value);
                return;
            }
            writer.WriteStartObject();

            WriteObject(writer, value);

            writer.WriteEndObject();
        }

        #region Helpers

        private void WriteValue(Utf8JsonWriter writer, object toWrite)
        {
            switch (toWrite)
            {
                case bool b:
                    writer.WriteBooleanValue(b);
                    break;
                case decimal dec:
                    writer.WriteNumberValue(dec);
                    break;
                case object o when o is string
                    || o is char:
                    writer.WriteStringValue(o.ToString());
                    break;
                case object o when o is sbyte
                    || o is short:
                    writer.WriteNumberValue((Int16)o);
                    break;
                case object o when o is int:
                    writer.WriteNumberValue((Int32)o);
                    break;
                case object o when o is long:
                    writer.WriteNumberValue((Int64)o);
                    break;
                case object o when o is byte
                    || o is ushort:
                    writer.WriteNumberValue((UInt16)o);
                    break;
                case object o when o is uint:
                    writer.WriteNumberValue((UInt32)o);
                    break;
                case object o when o is ulong:
                    writer.WriteNumberValue((UInt64)o);
                    break;
                case object o when o is float
                    || o is double:
                    writer.WriteNumberValue((double)o);
                    break;
                case object o when o is Enum:
                    switch (Enum.GetUnderlyingType(o.GetType()))
                    {
                        case Type t when t == typeof(int):
                            writer.WriteNumberValue((int)o);
                            break;
                        default:
                            throw new JsonException($"Unable to serialize enumeration {o.GetType().FullName}");
                    }

                    break;
                default:
                    throw new JsonException($"Unable to serialize property with value {toWrite}");
            }
        }

        private void WriteObject(Utf8JsonWriter writer, object toWrite)
        {
            PropertyInfo[] props = toWrite.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                object value = prop.GetValue(toWrite);
                Type propType = value?.GetType();

                Attribute jsonName = prop.GetCustomAttribute(typeof(JsonPropertyNameAttribute));
                string propName = (jsonName as JsonPropertyNameAttribute)?.Name ?? prop.Name.ToString();

                if (value == null && propName == "d")
                {
                    writer.WritePropertyName(propName);
                    writer.WriteNullValue();
                }
                else if (value != null)
                {
                    writer.WritePropertyName(propName);
                    if (propType.IsValueType || propType == typeof(string))
                    {
                        WriteValue(writer, value);
                    }
                    // TODO: figure out arrays
                    else if (propType.IsClass)
                    {
                        writer.WriteStartObject();
                        WriteObject(writer, value);
                        writer.WriteEndObject();
                    }
                    else
                    {
                        throw new JsonException($"Unable to serilize type {toWrite.GetType().Name}");
                    }
                }
            }
        }

        private Type DeterminePayloadDataType(GatewayPayload payload)
        {
            Type payloadDataType = null;
            switch (payload.Code)
            {
                case OpCodes.Gateway.Dispatch:
                    switch (payload.EventName)
                    {
                        case GatewayEventNames.Ready:
                            payloadDataType = typeof(GatewayReady);
                            break;
                        case GatewayEventNames.GuildCreate:
                            payloadDataType = typeof(GatewayGuild);
                            break;
                    }
                    break;
                case OpCodes.Gateway.Hello:
                    payloadDataType = typeof(GatewayHello);
                    break;
                case OpCodes.Gateway.HeartbeatACK:  // no data included
                    break;
            }
            return payloadDataType;
        }

        private void ParseDataValue(ref Utf8JsonReader reader, ref GatewayPayload payload, JsonElement dataValue)
        {
            Type payloadDataType = DeterminePayloadDataType(payload);
            bool validType = typeof(IGatewayDataMessage).IsAssignableFrom(payloadDataType);
            if (validType)
            {
                IGatewayDataMessage res = (IGatewayDataMessage)JsonSerializer.Deserialize(dataValue.ToString(), payloadDataType);
                payload.Data = res ?? throw new JsonException($"Unable to deserialize payload data type {payloadDataType.Name}");
            }
        }

        private void WriteHeartbeat(Utf8JsonWriter writer, GatewayPayload value)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("op");
            writer.WriteNumberValue((int)value.Code);

            writer.WritePropertyName("d");
            
            if (value.SequenceNumber > 0)
                writer.WriteNumberValue(value.SequenceNumber.GetValueOrDefault());
            else
                writer.WriteNullValue();

            writer.WriteEndObject();
        }

        #endregion

        //private class GatewayDataMessageConverter<GType> : JsonConverter<GType>
        //    where GType : IGatewayDataMessage
        //{
        //    public override GType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public override void Write(Utf8JsonWriter writer, GType value, JsonSerializerOptions options)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
