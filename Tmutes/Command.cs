using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using RemoteAdmin;
using System;
using System.Linq;

namespace TmutePlugin.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class TmuteCommand : ICommand
    {
        public string Command => "tmute";
        public string[] Aliases => Array.Empty<string>();
        public string Description => "Temporarily mute a player for a custom duration and reason.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 3)
            {
                response = "Usage: tmute <player> <duration> <reason>";
                return false;
            }

            if (!sender.CheckPermission("timedmute.mute"))
            {
                response = "You do not have permission to use this command.";
                return false;
            }

            var playerNameOrId = arguments.At(0);
            var durationString = arguments.At(1);
            var reason = string.Join(" ", arguments.Skip(2));

            var player = Player.Get(playerNameOrId);
            if (player == null)
            {
                response = "Player not found.";
                return false;
            }

            int durationSeconds;
            try
            {
                durationSeconds = Main.ParseDuration(durationString);
            }
            catch
            {
                response = "Invalid duration format. Use 1d, 2h, 30m, etc.";
                return false;
            }

            var muteEntry = new Main.MuteEntry
            {
                SteamId = player.UserId,
                ReasonBroadcast = reason,
                ExpireTime = DateTime.UtcNow.AddSeconds(durationSeconds)
            };

            Main.ActiveMutes.Add(muteEntry);
            Main.SaveMutes();

            var broadcast = Main.Instance.Config.MutedReason
                .Replace("{reason}", reason)
                .Replace("{duration}", durationString);

            player.IsMuted = true;
            player.Broadcast(10, broadcast);

            string senderName = sender is PlayerCommandSender playerSender
                ? playerSender.ReferenceHub.nicknameSync.Network_myNickSync
                : sender.ToString();

            DiscordHandler.SendMuteLog(player.Nickname, senderName, durationString, reason);

            response = $"Player {player.Nickname} has been muted for {durationString}. Reason: {reason}";
            return true;
        }
    }
}