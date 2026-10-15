namespace MiniRPG;

public interface ICombatant
{ 
    int MaxHealth { get; }
    int CurrentHealth { get; }
    int BaseAttackPower { get; }
    double TotalAttackPower { get; }
    void TakeDamage(int damage);
    bool IsAlive { get; }
    bool ConsumeEmpower();
}