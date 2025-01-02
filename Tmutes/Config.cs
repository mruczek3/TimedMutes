using Exiled.API.Interfaces;

namespace TmutePlugin
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        public string DiscordWebhookUrl { get; set; } = "URL";
        public string MutedReason { get; set; } = "You have been muted for {duration}. Reason: {reason}.";
        public string MuteExpired { get; set; } = "Your mute has expired.";
    }
}
