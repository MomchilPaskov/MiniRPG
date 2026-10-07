namespace MiniRPG;

public abstract class Character : IPlayable
{
    public string Name { get; set; }
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public int AttackPower { get; private set; }
    public bool IsAlive => CurrentHealth > 0;
    public int Gold { get;  private set; }

    protected Character(string name, int maxHealth, int attackPower)
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

    public void Heal(int heal)
    {
        if (heal < 0)
        {
            Console.WriteLine("You can't heal a negative amount!");
            return;
        }

        CurrentHealth = Math.Min(MaxHealth, CurrentHealth + heal);
    }

    public void AddGold(int gold)
    {
        Gold += gold;
    }

    public bool TrySpendingGold(int amount)
    {
        if (Gold - amount < 0)
            return false;
        return true;
    }
}