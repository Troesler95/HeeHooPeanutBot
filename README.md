# Hee-Hoo Peanut Bot
This is a Discord bot written in C# for my personal Discord server so I can mess around with my family and friends. It isn't going to be a very good bot, and it will definitely be chaotic, but it will be mine and that counts for something right?

Yes, I did code this bot from scratch using just the [Discord REST API](https://discord.com/developers/docs/reference#api-reference) and the [Discord Gateway](https://discord.com/developers/docs/topics/gateway). I am fully aware that there is already an amazing C# NuGet package that does everything I'm doing and then some over at [Discord.NET](https://github.com/discord-net/Discord.Net). But that's not the point! I wanted to test my skills and make something wholly my own, so here we are. You have my take on how to get everything working. I tried my best to have the bot have a sensible architecture and code organization, and am learning lessons as I go on. It's been a really fun project!

## Technology Overview
The bot is coded using a simple .NET Core 3.1 console app. Something neat I made sure to take advantage of was the new [System.Text.Json namespace](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-apis/) to handle the JSON interactions with Discord.

## Hee-Hoo What Now?
For those curious, the name is from an internet meme (Tumblr post that's screenshotted really) referencing a Reddit post. I'll let the meme speak for itself:

![](https://i.redd.it/3wocnzuootl21.png)

_source: https://www.reddit.com/r/tumblr/comments/b0ia0i/monky/_

Unfortunately I don't know if that's the original or what, that's something that's been lost to the internet. However here's the reddit post about the monkeys if you care: 
> [TIL a group of 15 monkeys escaped a research institute in Japan by using trees to catapult themselves over a 17ft high electric fence one by one.](https://www.reddit.com/r/todayilearned/comments/7qsikv/til_a_group_of_15_monkeys_escaped_a_research/).