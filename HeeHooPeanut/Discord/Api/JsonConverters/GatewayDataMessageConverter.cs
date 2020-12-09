using HeeHooPeanut.Discord.Api.Gateway;
using HeeHooPeanut.Discord.Api.Gateway.Events;
using HeeHooPeanut.Discord.Api.Gateway.Identify;
using HeeHooPeanut.Discord.Interfaces.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HeeHooPeanut.Discord.Api.JsonConverters
{
    // TODO: Replace this with a factory converter
    //public class GatewayPayloadDataConverter : JsonConverter<IGatewayDataMessage>
    //{
    //    private IReadOnlyList<Type> supportedTypes = new List<Type>
    //    {
    //        typeof(GatewayHello),
    //        typeof(GatewayIdentify),
    //        typeof(GatewayReady)
    //    }.AsReadOnly();

    //    public override IGatewayDataMessage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        if (reader.TokenType != JsonTokenType.StartObject)
    //        {
    //            throw new JsonException();
    //        }
    //        // forward to property name
    //        reader.Read();

    //        // This searches all types in the code. Is it necessary?
    //        //Type gatewayMissionInferface = typeof(IGatewayDataMessage);
    //        //IEnumerable<Type> possibleTypes = AppDomain.CurrentDomain.GetAssemblies()
    //        //    .SelectMany(s => s.GetTypes())
    //        //    .Where(t => !gatewayMissionInferface.Equals(t) && gatewayMissionInferface.IsAssignableFrom(t));

    //        // sanity check
    //        IEnumerable<Type> possibleTypes = supportedTypes.Where(t => typeof(IGatewayDataMessage).IsAssignableFrom(t));

    //        string propName = reader.GetString();
    //        bool matchFound = false;
    //        Type foundType = null;

    //        IGatewayDataMessage data = null;

    //        // try to find the current property name in all possible property names
    //        // once found, we will later fill out the object
    //        // TODO: this wasn't as smart as I thought it would be... several types start with "id"! 
    //        foreach (Type t in possibleTypes)
    //        {
    //            if (matchFound)
    //                break;

    //            var props = t.GetProperties();
    //            foreach (PropertyInfo prop in props)
    //            {
    //                Attribute attr = Attribute.GetCustomAttributes(prop).FirstOrDefault(a => a.GetType() == typeof(JsonPropertyNameAttribute));
    //                if (attr != null)
    //                {
    //                    JsonPropertyNameAttribute jsonProp = attr as JsonPropertyNameAttribute;
    //                    if (jsonProp?.Name == propName)
    //                    {
    //                        matchFound = true;
    //                        foundType = t;
    //                        break;
    //                    }
    //                }
    //            }
    //        }

    //        data = (IGatewayDataMessage)Activator.CreateInstance(foundType);

    //        if (!matchFound || data == null)
    //            throw new JsonException($"Unable to match property name {propName} to any known type that inherits IGatewayDataMessage.");
    //        return (IGatewayDataMessage) ReadObject(ref reader, foundType);
    //    }

    //    private object ReadValue(ref Utf8JsonReader reader, Type propType)
    //    {
    //        object retVal = null;
    //        switch (reader.TokenType)
    //        {
    //            case JsonTokenType.StartObject:
    //                // TODO
    //                retVal = ReadObject(ref reader, propType);
    //                break;
    //            case JsonTokenType.StartArray:
    //                // TODO
    //                break;
    //            case JsonTokenType.String:
    //                retVal = reader.GetString();
    //                break;
    //            case JsonTokenType.Number:
    //                switch (propType)
    //                {
    //                    case object o when o is byte:
    //                        retVal = reader.GetByte();
    //                        break;
    //                    case object o when o is sbyte:
    //                        retVal = reader.GetSByte();
    //                        break;
    //                    case object o when o is short:
    //                        retVal = reader.GetInt16();
    //                        break;
    //                    case object o when o is ushort:
    //                        retVal = reader.GetUInt16();
    //                        break;
    //                    case object o when o is int:
    //                        retVal = reader.GetInt32();
    //                        break;
    //                    case object o when o is uint:
    //                        retVal = reader.GetUInt32();
    //                        break;
    //                    case object o when o is long:
    //                        retVal = reader.GetInt64();
    //                        break;
    //                    case object o when o is decimal:
    //                        retVal = reader.GetDecimal();
    //                        break;
    //                    case object o when o is double:
    //                        retVal = reader.GetDouble();
    //                        break;
    //                    default:
    //                        throw new JsonException($"Unable to read number value with type {propType}");
    //                }
    //                break;
    //            case JsonTokenType.True:
    //                retVal = true;
    //                break;
    //            case JsonTokenType.False:
    //                retVal = false;
    //                break;
    //            case JsonTokenType.Null:
    //            default:
    //                break;
    //        }
    //        return retVal;
    //    }

    //    private object ReadObject(ref Utf8JsonReader reader, Type toFill)
    //    {
    //        object retVal = null;
    //        if (toFill != null)
    //        {
    //            retVal = Activator.CreateInstance(toFill);
    //            int curDepth = reader.CurrentDepth;
    //            string propName = string.Empty;

    //            while (reader.Read())
    //            {
    //                if (reader.TokenType == JsonTokenType.EndObject && reader.CurrentDepth == 1)
    //                {
    //                    break;
    //                }
    //                else if (reader.TokenType == JsonTokenType.PropertyName)
    //                {
    //                    propName = reader.GetString();
    //                }
    //                else
    //                {
    //                    // fields starting with an underscore should be ignored
    //                    // see https://discord.com/developers/docs/topics/gateway#gateways
    //                    if (propName.StartsWith('_'))
    //                        continue;

    //                    // get property out of class
    //                    PropertyInfo prop = (from p in toFill.GetProperties()
    //                                         where Attribute.GetCustomAttributes(p)
    //                                            .FirstOrDefault(a => a.GetType() == typeof(JsonPropertyNameAttribute) && (a as JsonPropertyNameAttribute).Name == propName) != null
    //                                         select p).FirstOrDefault();

    //                    object val = ReadValue(ref reader, prop.PropertyType);
    //                    if (prop != null && val != null)
    //                    {
    //                        prop.SetValue(retVal, val);
    //                    }
    //                }
    //            }
    //        }

    //        return retVal;
    //    }

    //    private void WriteValue(Utf8JsonWriter writer, object toWrite)
    //    {
    //        switch(toWrite)
    //        {
    //            case bool b:
    //                writer.WriteBooleanValue(b);
    //                break;
    //            case decimal dec:
    //                writer.WriteNumberValue(dec);
    //                break;
    //            case object o when o is string
    //                || o is char:
    //                writer.WriteStringValue(o.ToString());
    //                break;
    //            case object o when o is sbyte
    //                || o is short:
    //                writer.WriteNumberValue((Int16)o);
    //                break;
    //            case object o when o is int:
    //                writer.WriteNumberValue((Int32)o);
    //                break;
    //            case object o when o is long:
    //                writer.WriteNumberValue((Int64)o);
    //                break;
    //            case object o when o is byte
    //                || o is ushort:
    //                writer.WriteNumberValue((UInt16)o);
    //                break;
    //            case object o when o is uint:
    //                writer.WriteNumberValue((UInt32)o);
    //                break;
    //            case object o when o is ulong:
    //                writer.WriteNumberValue((UInt64)o);
    //                break;
    //            case object o when o is float
    //                || o is double:
    //                writer.WriteNumberValue((double)o);
    //                break;
    //            case object o when o is Enum:
    //                switch(Enum.GetUnderlyingType(o.GetType()))
    //                {
    //                    case Type t when t == typeof(int):
    //                        writer.WriteNumberValue((int)o);
    //                        break;
    //                    default:
    //                        throw new JsonException($"Unable to serialize enumeration {o.GetType().FullName}");
    //                }
                    
    //                break;
    //            default:
    //                throw new JsonException($"Unable to serialize property with value {toWrite}");
    //        }
    //    }

    //    private void WriteObject(Utf8JsonWriter writer, object toWrite)
    //    {
    //        PropertyInfo[] props = toWrite.GetType().GetProperties();

    //        foreach(PropertyInfo prop in props)
    //        {
    //            object value = prop.GetValue(toWrite);
    //            Type propType = value?.GetType();

    //            if (value != null)
    //            {
    //                Attribute jsonName = prop.GetCustomAttribute(typeof(JsonPropertyNameAttribute));
    //                writer.WritePropertyName((jsonName as JsonPropertyNameAttribute)?.Name ?? prop.Name.ToString());

    //                if (propType.IsValueType || propType == typeof(string))
    //                {
    //                    WriteValue(writer, value);
    //                }
    //                // TODO: figure out arrays
    //                else if (propType.IsClass)
    //                {
    //                    writer.WriteStartObject();
    //                    WriteObject(writer, value);
    //                    writer.WriteEndObject();
    //                }
    //                else
    //                {
    //                    throw new JsonException($"Unable to serilize type {toWrite.GetType().Name}");
    //                }
    //            }
    //        }
    //    }

    //    public override void Write(Utf8JsonWriter writer, IGatewayDataMessage value, JsonSerializerOptions options)
    //    {
    //        // this is a property within a type, so don't start off by writing a start obj
    //        writer.WriteStartObject();

    //        WriteObject(writer, value);

    //        writer.WriteEndObject();
    //    }
    //}
}
