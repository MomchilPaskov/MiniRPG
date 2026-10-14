using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace MiniRPG;

public class ShopEncounter : IEncounter
{
    public string Name => "Shop";
    public string Description => "";

    public bool BuyItem(IPlayable player, List<Item> stock)
    {
        Console.Clear();
        
        if (stock.Count == 0)
        {
            Console.WriteLine("The shop is empty.");
            Console.ReadKey(true);
            return false;
        }
        Console.WriteLine("You are in the shop.");
        Console.WriteLine($"You have {player.Gold}gold");
        Console.WriteLine("Choose an item to buy.");
        Console.WriteLine("(Click the number!)");

        for (int i = 0; i < stock.Count; i++)
        {
            Console.WriteLine($"{i+1} - \"{stock[i].Name}\" {stock[i].Description}({stock[i].Price}gold)");
        }

        Console.WriteLine("0 - Leave");
        
        char key = Console.ReadKey(true).KeyChar;

        if (key == '0')
            return false;

        int index = key - '1';

        if (index < 0 || index >= stock.Count)
        {
            Console.WriteLine("That is not a valid option.");
        }
        else if (player.TrySpendingGold(stock[index].Price))
        {
            string boughtName = stock[index].Name;
            stock[index].Apply(player);
            stock[index].MarkPurchased();
            stock.RemoveAt(index);
            Console.WriteLine($"You bought {boughtName}. Press any key to continue.");
        }
        else
        {
            Console.WriteLine("Not enough gold. Press any key to continue.");
            Console.ReadKey(true);
        }
        return true;
    }

    public void Run(IPlayable player)
    {
        List<Item> stock = new List<Item>(ItemCatalog.All)
            .Where(i => !i.isPurchased)
            .OrderBy(_ => Random.Shared.Next())
            .Take(3)
            .ToList();;
        while (BuyItem(player, stock))
        {
        }
    }
}