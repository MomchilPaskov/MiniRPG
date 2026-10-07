namespace MiniRPG;

public class CombatSystem
{
    public static void Attack(ICombatant attacker, ICombatant defender)
    {
        defender.TakeDamage(attacker.AttackPower);
    }
    

    public static void Heal(IHealable user, int heal)
    {
        user.Heal(heal);
    }
    
    public void StartFight(IPlayable player, ICombatant enemy)
    {
        Console.Clear();
        Console.WriteLine($"A {enemy.Name} is trying to fight...");

        while (true)
        {
            Console.WriteLine($"Player max health: {player.MaxHealth}hp");
            Console.WriteLine($"Player current health: {player.CurrentHealth}hp");
            Console.WriteLine($"{enemy.Name} health: {enemy.CurrentHealth}hp");
            
            Console.WriteLine("attack or heal?");
            string? action = Console.ReadLine()?.Trim().ToLower();
            Console.Clear();

            bool playerActed = false;
            
            switch (action)
            {
                case "attack":
                    Console.WriteLine($"You attacked a {enemy.Name}!");
                    Attack(player, enemy);
                    playerActed = true;
                    break;
                case "heal":
                    if (player.CurrentHealth == player.MaxHealth)
                    {
                        Console.WriteLine("You can't heal when you are at max health!");
                    }
                    else
                    {
                        int amount = Math.Min(25, player.MaxHealth - player.CurrentHealth);
                        Heal(player, amount);
                        Console.WriteLine($"You healed {amount}hp.");
                        playerActed = true;
                    }
                    break;
 
                default:
                    Console.WriteLine("Please enter a valid action!");
                    break;

            }

            if (!playerActed)
            {
                continue;
            }

            if (!enemy.IsAlive)
            {
                Console.WriteLine("You won!");
                player.AddGold(100);
                return;
            }
            
            Attack(enemy, player); 
            Console.WriteLine($"Enemy attacked you for {enemy.AttackPower}hp");

            if (!player.IsAlive) 
            { 
                Console.WriteLine("You died!"); 
                return;
            }
            
            
        }
    }
}