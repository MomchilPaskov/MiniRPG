namespace MiniRPG;

public interface ICombatant
{ 
    string Name { get; }
    int MaxHealth { get; }
    int CurrentHealth { get; }
    int BaseAttackPower { get; }
    double TotalAttackPower { get; }
    void TakeDamage(int damage);
    bool IsAlive { get; }
}