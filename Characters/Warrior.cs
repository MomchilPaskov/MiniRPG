namespace MiniRPG;

public class Warrior : Character
{
    public Warrior(string name)
        : base(name)
    { 
        SetStats(
            maxHealth: 100,
            baseAttackPower: 20,
            defendPower: 35,
            healPower: 35);
    }
}