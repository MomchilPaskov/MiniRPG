namespace MiniRPG;

public class Enemy : ICombatant
{
    public string Name { get; set; }
    
    public int MaxHealth { get; private set; }
    
    public int CurrentHealth { get; private set; }
    public double TotalAttackPower => BaseAttackPower;

    public int BaseAttackPower { get; private set; }

    public bool IsAlive => CurrentHealth > 0;
    public bool ConsumeEmpower() => false;

    public Enemy(string name, int maxHealth, int baseAttackPower)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        BaseAttackPower = baseAttackPower;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Console.WriteLine("You can't take negative damage!");
            return;
        }
        
        CurrentHealth = Math.Max(0, CurrentHealth - damage);
    }

    public void ScaleToTier(int tier)
    {
        MaxHealth += tier * 75;
        CurrentHealth = MaxHealth;
        BaseAttackPower += tier *35;
    }
}