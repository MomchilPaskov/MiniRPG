namespace MiniRPG;

public class ForgeEncounter : IEncounter
{
    public string Name => "Forge";
    public string Description => "";

    private void ForgeStat(IPlayable player)
    {
        int dmgUpgrade = Random.Shared.Next(1, 10 + 1);
        int defUpgrade = Random.Shared.Next(1, 10 + 1);
        int healUpgrade = Random.Shared.Next(1, 10 + 1);
        int mhUpgrade = Random.Shared.Next(1, 10 + 1);

        while (true)
        {
            Console.WriteLine("You can upgrade your:\n" +
                              "(Click a number)\n" +
                              $"1 - Max Health {player.MaxHealth} -> {player.MaxHealth + mhUpgrade}\n" +
                              $"2 - Damage ({player.BaseAttackPower} -> {player.BaseAttackPower + dmgUpgrade})\n" +
                              $"3 - Defense ({player.DefendPower} -> {player.DefendPower + defUpgrade})\n" +
                              $"4 - Heal ({player.HealPower} -> {player.HealPower + healUpgrade})");

            char key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case '1':
                    player.AddStats(0, 0, 0, 0, mhUpgrade);
                    return;
                case '2':
                    player.AddStats(dmgUpgrade, 0, 0, 0, 0);
                    return;
                case '3':
                    player.AddStats(0, defUpgrade, 0, 0, 0);
                    return;
                case '4':
                    player.AddStats(0, 0, healUpgrade, 0, 0);
                    return;
                case '6':
                    player.AddStats(1000, 1000, 1000, 1000, 1000);
                    player.AddGold(10000);
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine($"{key} is not a valid key.");
                    break;
            }
        }
    }

    public void Run(IPlayable player)
    {
        Console.Clear();
        Console.WriteLine("You went to the forge.");
        while (true)
        {
            Console.WriteLine($"Do you want an upgrade?       Your gold: {player.Gold}");
            Console.WriteLine("Yes (-200gold)");
            Console.WriteLine("No (Return)");
            string? choice = Console.ReadLine()?.ToLower().Trim();
            if (choice == "yes")
            {
                if (player.TrySpendingGold(200))
                {
                    ForgeStat(player);
                    Console.WriteLine($"Your gold: {player.Gold}");
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You don't have enough gold. Press any key to continue.");
                    Console.ReadKey(true);
                    return;
                }
                
            }
            else if (choice == "no")
            {
                return;
            }
            else if (choice == "admin")
            {
                ForgeStat(player);
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{choice} is not a valid choice.");
            }
        }
    }
}