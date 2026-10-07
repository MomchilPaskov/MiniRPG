using MiniRPG;

public interface IPlayable : IHealable, ICombatant
{
    int Gold { get; }
    void AddGold(int amount);
    bool TrySpendingGold(int amount);
}