using System;
using MCGalaxy;

public class CmdBonus : Command
{
    public override string name { get { return "Bonus"; } }
    public override string shortcut { get { return ""; } }
    public override string type { get { return "other"; } }
    public override bool museumUsable { get { return true; } }
    public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }

    public override void Use(Player p, string message)
    {
        int bonusAmount = 20;

        p.SetMoney(p.money + bonusAmount);

        p.Message($"You have been awarded {bonusAmount} {Server.Config.Currency}!");
    }

    public override void Help(Player p)
    {
        p.Message("Bonus command: Awards the player with 20 " + Server.Config.Currency + ".");
    }
}