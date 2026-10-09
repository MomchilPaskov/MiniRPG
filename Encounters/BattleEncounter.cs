namespace MiniRPG;

public class BattleEncounter : IEncounter
{
    public string Name => "Battle";
    public string Description => "";
    public void Run(IPlayable player)
    {
        EnemyFactory ef = new EnemyFactory();
        CombatSystem cs = new CombatSystem();

        Enemy enemy = ef.Factory();
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
                    cs.Attack(player, enemy);
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
                        cs.Heal(player, amount);
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
            
            cs.Attack(enemy, player); 
            Console.WriteLine($"Enemy attacked you for {enemy.AttackPower}hp");

            if (!player.IsAlive) 
            { 
                Console.WriteLine("You died!"); 
                return;
            }
            
            
        }
    }
}