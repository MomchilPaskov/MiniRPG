namespace MiniRPG;

public class Mage : Character
{
    
    public  Mage(string name)
        : base(name)
    { 
        SetStats(
            maxHealth: 80,
            attackPower: 30,
            defendPower: 5,
            healPower: 20);
    }
}