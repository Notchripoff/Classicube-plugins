/*
CmdBanAll - Originally banned all online players from the server - Modified for meme usage here :)
@author Panda @Notchripoff "I'm editing this for my server"
*/
using MCGalaxy.Commands.Chatting;
using System;
using System.Threading.Tasks;

namespace MCGalaxy
{
    public class CmdHack : MessageCmd
    {
        private Random _random = new Random();
        public override string name { get { return "Hack"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "moderation"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }

        public override void Use(Player p, string message)
        {
            // Removed the call to CanSpeak, as it's not defined
            if (p.group.Permission >= LevelPermission.Admin)
            {
                double value = RandomRealBanAllChance(p);
                Chat.MessageChat(ChatScope.Global, p, $"%c[{p.group.Name}] {p.ColoredName}:%S Real Hack chance calculated: %c{value}. %SNeeded: %a420.69", null, null);
            }
            else
            {
                string suffix = RandomMessage();
                Chat.MessageChat(ChatScope.Global, p, p.ColoredName + " %SISSUED /Hack " + suffix, null, null);
            }
        }

        public string RandomMessage()
        {
            int val = _random.Next(12);

            switch (val)
            {
                case 0:
                    return "%cbut banned themself.";
                case 1:
                    return "%cbut spelled it wrong.";
                case 2:
                    return "%cbut forgot they're not staff.";
                case 3:
                    return "%cbut on the wrong server.";
                case 4:
                    return "%cbut broke their nail typing it.";
                case 5:
                    return "%cbut forgot Panda didn't import it yet.";
                case 6:
                    return "%cthinking they could ACTUALLY ban everyone LMAO!";
                case 7:
                    return "%cbut cancelled it JUST IN TIME!";
                case 8:
                    return "%cbut finally realized it won't ban ANYONE.";
                case 9:
                    return "%cand farted at the same time.";
                case 10:
                    return "%cbut hacked Panda's code so only Panda gets banned.";
                case 11:
                    return "%cbut LegoSpaceGuy hacked it into /lick.";
                default:
                    return "%cbut shit hit the fan. %cThis is an error message, contact @Panda";
            }
        }

        public double RandomRealBanAllChance(Player p)
        {
            // Calculate a random value between 0 and 10,000 (0.01% chance of occurrence)
            double value = Math.Round((_random.NextDouble() * 10001), 2);

            // If we hit this god-forsaken value... let Panda have his fun :D
            if (value == 420.69)
            {
                Chat.MessageGlobal($"{p.ColoredName} %cHAS ACTIVATED THE REAL BANALL (%A0.01% CHANCE FOR ADMINS+%c).");
                Chat.MessageGlobal("%cALL ONLINE PLAYERS WILL BE TEMPBANNED IN 3 SECONDS.");

                // Use a timer or scheduling mechanism instead of Thread.Sleep
                Task.Delay(3000).ContinueWith(t =>
                {
                    // Ban all online users for 1 day
                    Player[] onlineUsers = PlayerInfo.Online.Items;
                    foreach (Player user in onlineUsers)
                    {
                        Command.Find("tempban").Use(Player.Console, user.name + " 1d BANALL by " + p.name + ".");
                        Command.Find("kick").Use(Player.Console, user.name + " Banned for 1d by " + p.name + " using BANALL!");
                    }
                });
            }
            return value;
        }

        public override void Help(Player p)
        {
            p.Message("/Hack- Ban everyone... Literally.");
        }
    }
}