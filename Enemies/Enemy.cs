namespace MiniRPG;

public abstract class Enemy : ICombatant
{
    public string Name { get; set; }
    
    public int MaxHealth { get; private set; }
    
    public int CurrentHealth { get; private set; }
    
    public int AttackPower { get; private set; }

    public bool IsAlive => CurrentHealth > 0;

    public Enemy(string name, int maxHealth, int attackPower)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        AttackPower = attackPower;
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
}