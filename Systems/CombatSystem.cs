namespace MiniRPG;

public class CombatSystem
{
    public void Attack(ICombatant attacker, ICombatant defender)
    {
        double damageDealt = attacker.TotalAttackPower;

        if (attacker.ConsumeEmpower())
        {
            damageDealt *= 2;
        }
        defender.TakeDamage((int)Math.Round(damageDealt, MidpointRounding.AwayFromZero));
    }
    

    public void Heal(IHealable user, int heal)
    {
        user.Heal(heal);
    }

    public void Defend(IPlayable user)
    {
        Console.WriteLine("Your next attack will be empowered! (x2)");
        user.StartDefending(user);
        
    }
}