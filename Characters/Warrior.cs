namespace MiniRPG;

public class Warrior : Character
{
    public Warrior(string name)
        : base(name)
    { 
        SetStats(
            maxHealth: 100,
            attackPower: 20,
            defendPower: 5,
            healPower: 20);
    }
}