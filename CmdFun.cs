// Reference other assemblies if needed
// For example: //reference MCGalaxy.dll

using System;
using MCGalaxy;

public class CmdFun : Command
{
    // The command's name (what you put after a slash to use this command)
    public override string name { get { return "Fun"; } }

    // Command's shortcut, can be left blank (e.g. "/Copy" has a shortcut of "c")
    public override string shortcut { get { return ""; } }

    // Which submenu this command displays in under /Help
    public override string type { get { return "other"; } }

    // Whether or not this command can be used in a museum. Block/map altering commands should return false to avoid errors.
    public override bool museumUsable { get { return true; } }

    // The default rank required to use this command. Valid values are:
    //   LevelPermission.Guest, LevelPermission.Builder, LevelPermission.AdvBuilder,
    //   LevelPermission.Operator, LevelPermission.Admin, LevelPermission.Owner
    public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }

    // This is for when a player executes this command by doing /Fun
    //   p is the player object for the player executing the command. 
    //   message is the arguments given to the command. (e.g. for '/Fun this', message is "this")
    public override void Use(Player p, string message)
    {
        // Kick the player with the message
        p.Kick("NO FUN HERE!! lol");
    }

    // This is for when a player does /Help Fun
    public override void Help(Player p)
    {
        p.Message("/Fun - Kicks you with a message saying \"NO FUN HERE!! lol\"");
    }
}


