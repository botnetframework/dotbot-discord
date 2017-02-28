using User = Discord.User;
using LogSeverity = Discord.LogSeverity;
using Profile = Discord.Profile;
using Channel = Discord.Channel;
using Dotbot.Diagnostics;

namespace Dotbot.Discord
{
    public static class DiscordExtensions
    {
        public static Dotbot.Models.User ToBotUser(this User user)
        {
            return new Dotbot.Models.User
            {
                Id = user.Id.ToString(),
                Username = user.Nickname,
                DisplayName = user.Name
            };
        }

        public static Dotbot.Models.User ToBotUser(this Profile profile) {
            return new Dotbot.Models.User {
                Id = profile.Id.ToString(),
                Username = profile.Email,
                DisplayName = profile.Name
            };
        }
        public static LogLevel ToLogLevel(this LogSeverity severity)
        {
            switch (severity)
            {
                case LogSeverity.Debug:
                    return LogLevel.Debug;
                case LogSeverity.Error:
                    return LogLevel.Error;
                case LogSeverity.Info:
                    return LogLevel.Information;
                case LogSeverity.Verbose:
                    return LogLevel.Verbose;
                case LogSeverity.Warning:
                    return LogLevel.Warning;
                default:
                    return LogLevel.Fatal;
            }
        }

        public static Dotbot.Models.Room ToRoom(this Channel channel) {
            return new Dotbot.Models.Room {
                Id = channel.Id.ToString(),
                Name = channel.Name
            };
        }
    }
}