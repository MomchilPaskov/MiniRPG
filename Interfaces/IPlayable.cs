namespace MiniRPG;

public interface IPlayable : IHealable, ICombatant
{
    int Gold { get; }
    void AddGold(int amount);
    bool TrySpendingGold(int amount);
    int DefendPower { get; }
    void StartDefending (IPlayable user);
    int HealPower { get; }
    void AddStats(int damage, int defense, int heal, double dmgMultiplier, int maxHealth);
    void RoundWon();
    int RoundCount { get; }
}