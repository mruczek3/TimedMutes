using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Timers;
using Exiled.API.Features;
using Newtonsoft.Json;
using Exiled.Events.EventArgs.Player;

namespace TmutePlugin
{
    public class Main : Plugin<Config>
    {
        public override string Name => "Tmute";
        public override string Author => "mruczek";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(9, 0, 0);

        private static string MutesFilePath => Path.Combine(Paths.Configs, "tmutes.json");
        public static List<MuteEntry> ActiveMutes = new List<MuteEntry>();
        public static Main Instance;

        private Timer MuteChecker;

        public override void OnEnabled()
        {
            Instance = this;
            LoadMutes();

            MuteChecker = new Timer(60000);
            MuteChecker.Elapsed += CheckExpiredMutes;
            MuteChecker.Start();

            Exiled.Events.Handlers.Player.Verified += OnPlayerVerified;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            SaveMutes();

            MuteChecker?.Stop();
            MuteChecker?.Dispose();

            Exiled.Events.Handlers.Player.Verified -= OnPlayerVerified;
            Instance = null;
            base.OnDisabled();
        }

        private void LoadMutes()
        {
            if (File.Exists(MutesFilePath))
            {
                var json = File.ReadAllText(MutesFilePath);
                ActiveMutes = JsonConvert.DeserializeObject<List<MuteEntry>>(json) ?? new List<MuteEntry>();
            }
        }

        public static void SaveMutes()
        {
            var json = JsonConvert.SerializeObject(ActiveMutes, Formatting.Indented);
            File.WriteAllText(MutesFilePath, json);
        }

        private void OnPlayerVerified(VerifiedEventArgs ev)
        {
            var mute = ActiveMutes.FirstOrDefault(m => m.SteamId == ev.Player.UserId);
            if (mute != null && DateTime.UtcNow < mute.ExpireTime)
            {
                ev.Player.IsMuted = true;

                var broadcast = Config.MutedReason
                    .Replace("{reason}", mute.ReasonBroadcast)
                    .Replace("{duration}", GetDuration(mute.ExpireTime));
                ev.Player.Broadcast(10, broadcast);
            }
        }

        private void CheckExpiredMutes(object sender, ElapsedEventArgs e)
        {
            bool changesMade = false;

            foreach (var mute in ActiveMutes.ToList())
            {
                if (DateTime.UtcNow >= mute.ExpireTime)
                {
                    var player = Player.List.FirstOrDefault(p => p.UserId == mute.SteamId);
                    if (player != null)
                    {
                        player.IsMuted = false;
                        player.Broadcast(5, Config.MuteExpired);
                    }

                    ActiveMutes.Remove(mute);
                    changesMade = true;
                }
            }

            if (changesMade)
                SaveMutes();
        }

        private string GetDuration(DateTime expireTime)
        {
            TimeSpan remaining = expireTime - DateTime.UtcNow;
            if (remaining.TotalDays >= 1)
                return ((int)remaining.TotalDays) + "d";
            if (remaining.TotalHours >= 1)
                return ((int)remaining.TotalHours) + "h";
            if (remaining.TotalMinutes >= 1)
                return ((int)remaining.TotalMinutes) + "m";
            return ((int)remaining.TotalSeconds) + "s";
        }

        public class MuteEntry
        {
            public string SteamId { get; set; }
            public string ReasonBroadcast { get; set; }
            public DateTime ExpireTime { get; set; }
        }

        public static int ParseDuration(string duration)
        {
            var regex = new Regex(@"(?<value>\d+)(?<unit>[smhd])");
            int totalSeconds = 0;

            foreach (Match match in regex.Matches(duration))
            {
                int value = int.Parse(match.Groups["value"].Value);
                string unit = match.Groups["unit"].Value.ToLower();

                if (unit == "s")
                    totalSeconds += value;
                else if (unit == "m")
                    totalSeconds += value * 60;
                else if (unit == "h")
                    totalSeconds += value * 3600;
                else if (unit == "d")
                    totalSeconds += value * 86400;
            }

            return totalSeconds;
        }
    }
}
