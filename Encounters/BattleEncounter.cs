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

        int healCooldown = 0;
        int defCooldown = 0;
        
        while (true)
        {
            Console.WriteLine($"Player max health: {player.MaxHealth}hp");
            Console.WriteLine($"Player current health: {player.CurrentHealth}hp");
            Console.WriteLine($"{enemy.Name} health: {enemy.CurrentHealth}hp");

            string healStatus = healCooldown > 0 ? $"{healCooldown} turns left" : "ready";
            string defStatus = defCooldown > 0 ? $"{defCooldown} turns left" : "ready";
            
            Console.WriteLine($"Attack | Defend({defStatus}) | Heal({healStatus}).");
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
                case "defend":
                    if (defCooldown <= 0)
                    {
                        Console.WriteLine($"You will defend the next attack for {player.DefendPower}");
                        cs.Defend(player);
                        playerActed = true;
                        defCooldown = 3;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"This ability is on cooldown for {defCooldown} turns.");
                        break;
                    }
                case "heal":
                    if (player.CurrentHealth == player.MaxHealth)
                    {
                        Console.WriteLine("You can't heal when you are at max health!");
                    }
                    else
                    {
                        if (healCooldown <= 0)
                        {
                            int amount = Math.Min(player.HealPower, player.MaxHealth - player.CurrentHealth);
                            cs.Heal(player, amount);
                            Console.WriteLine($"You healed {amount}hp.");
                            playerActed = true;
                            healCooldown = 3;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"This ability is on cooldown for {healCooldown} turns.");
                            break;
                        }
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
            
            healCooldown = Math.Max(0, healCooldown - 1);
            defCooldown = Math.Max(0, defCooldown - 1);
            
            if (!enemy.IsAlive)
            {
                Console.WriteLine("You won!");
                player.AddGold(100);
                return;
            }
            
            int hpBefore = player.CurrentHealth;
            
            
            cs.Attack(enemy, player); 
            
            int taken = hpBefore - player.CurrentHealth;
            Console.WriteLine($"{enemy.Name} attacked you! (-{taken}hp)");

            if (!player.IsAlive) 
            { 
                Console.WriteLine("You died!"); 
                return;
            }
            
            
        }
    }
}