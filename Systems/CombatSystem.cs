namespace MiniRPG;

public class CombatSystem
{
    public void Attack(ICombatant attacker, ICombatant defender)
    {
        defender.TakeDamage((int)Math.Round(attacker.TotalAttackPower, MidpointRounding.AwayFromZero));
    }
    

    public void Heal(IHealable user, int heal)
    {
        user.Heal(heal);
    }

    public void Defend(IPlayable user)
    {
        user.StartDefending(user);
    }
}