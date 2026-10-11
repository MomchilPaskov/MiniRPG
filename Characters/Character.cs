namespace MiniRPG;

public abstract class Character : IPlayable
{
    public string Name { get; set; }
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public int AttackPower { get; private set; }
    public int DefendPower { get; private set; }
    public int HealPower { get; private set; }
    public bool IsAlive => CurrentHealth > 0;
    public int Gold { get;  private set; }
    public bool IsDefending {get; private set;}

    protected Character(string name)
    {
        Name = name;
    }

    protected void SetStats(int maxHealth, int attackPower, int defendPower, int healPower)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        AttackPower = attackPower;
        DefendPower = defendPower;
        HealPower = healPower;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Console.WriteLine("You can't take negative damage!");
            return;
        }
        
        int finalDamage = damage;
        if (IsDefending)
        {
            finalDamage = Math.Max(0, damage - DefendPower);
            IsDefending = false;
        }
        
        CurrentHealth = Math.Max(0, CurrentHealth - finalDamage);
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

    public void StartDefending(IPlayable user)
    {
        IsDefending = true;
    }

    public void AddGold(int gold)
    {
        Gold += gold;
    }

    public bool TrySpendingGold(int amount)
    {
        if (Gold - amount < 0 || Gold < amount)
            return false;
        Gold -= amount;
        return true;
    }

    public void AddStats(int damage, int defense, int heal)
    {
        AttackPower += damage;
        DefendPower += defense;
        HealPower += heal;
    }
}