namespace MiniRPG;

public class Archer : Character
{
    private CombatSystem cs = new CombatSystem();
    public Archer(string name)
        : base(name)
    { 
        SetStats(
            maxHealth: 110,
            baseAttackPower: 10,
            defendPower: 5,
            healPower: 20);
    }
    
}