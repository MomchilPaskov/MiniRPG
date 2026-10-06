namespace MiniRPG;

public class CombatSystem
{
    public static void Attack(Character attacker, Enemy defender)
    {
        defender.TakeDamage(attacker.AttackPower);
    }
    public static void Attack(Enemy attacker, Character defender)
    {
        defender.TakeDamage(attacker.AttackPower);
    }

    public static void Heal(Character user, int heal)
    {
        user.Heal(heal);
    }
    
    public void StartFight(Character player, Enemy enemy)
    {
        Console.Clear();
        Console.WriteLine($"A {enemy.Name} is trying to fight...");
        bool inFight = true;

        while (inFight)
        {
            Console.WriteLine($"Player max health: {player.MaxHealth}hp");
            Console.WriteLine($"Player current health: {player.CurrentHealth}hp");
            Console.WriteLine($"{enemy.Name} health: {enemy.CurrentHealth}hp");
            
            Console.WriteLine("attack or heal?");
            string action = Console.ReadLine().ToLower();
            Console.Clear();
            switch (action)
            {
                case "attack":
                    Console.WriteLine($"You attacked a {enemy.Name}!");
                    Attack(player, enemy);
                    break;
                case "heal":
                    if (player.CurrentHealth < player.MaxHealth - 25)
                    {
                        Console.WriteLine("You restore 25hp.");
                        Heal(player, 25);
                        break;
                    }
                    else if (player.CurrentHealth == player.MaxHealth)
                    {
                        Console.WriteLine("You cant heal when you are max health!");
                        Heal(player, enemy.AttackPower);
                        break;
                    }
                    else
                    {
                        int diff = player.MaxHealth - player.CurrentHealth;
                        Console.WriteLine($"You healed {diff}hp.");
                        Heal(player, diff);
                        break;
                    }
                default:
                    Console.WriteLine("Please enter a valid action!");
                    Heal(player, enemy.AttackPower);
                    break;
            }

            if (enemy.CurrentHealth <= 0)
            {
                Console.WriteLine("You won!");
                inFight = false;
            }
            else
            {
                Attack(enemy, player);
                Console.WriteLine($"Enemy attacked you for {enemy.AttackPower}hp");

                if (player.CurrentHealth <= 0)
                {
                    Console.WriteLine("You died!");
                    inFight = false;
                }
            }
            
        }
    }
}