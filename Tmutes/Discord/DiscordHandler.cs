using System.Net;
using System.Text;

namespace TmutePlugin
{
    public static class DiscordHandler
    {
        public static void SendMuteLog(string mutedPlayer, string adminName, string duration, string reason)
        {
            string webhookUrl = Main.Instance.Config.DiscordWebhookUrl;
            if (string.IsNullOrEmpty(webhookUrl))
                return;

            string json = $@"
            {{
                ""embeds"": [
                    {{
                        ""title"": ""Mute Log"",
                        ""description"": ""A player was muted on the server."",
                        ""color"": 16711680,
                        ""fields"": [
                            {{ ""name"": ""Player Muted"", ""value"": ""{mutedPlayer}"", ""inline"": true }},
                            {{ ""name"": ""Muted By"", ""value"": ""{adminName}"", ""inline"": true }},
                            {{ ""name"": ""Duration"", ""value"": ""{duration}"", ""inline"": true }},
                            {{ ""name"": ""Reason"", ""value"": ""{reason}"", ""inline"": true }}
                        ]
                    }}
                ]
            }}";

            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.UploadString(webhookUrl, "POST", json);
            }
        }
    }
}
