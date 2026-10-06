namespace MiniRPG;

public abstract class Enemy
{
    public string Name { get; set; }
    
    public int MaxHealth { get; private set; }
    
    public int CurrentHealth { get; private set; }
    
    public int AttackPower { get; private set; }

    public Enemy(string name, int maxHealth, int attackPower)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        AttackPower = attackPower;
    }

    public void TakeDamage(int damage)
    {
        if (damage >= 0)
            CurrentHealth -= damage;
        else
            Console.WriteLine("You can't take negative damage!");
    }
}