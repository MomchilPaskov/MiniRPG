namespace MiniRPG;

public class ShopEncounter : IEncounter
{
    public string Name => "Shop";
    public string Description => "";

    public void BuyItem(IPlayable player)
    {
        Console.WriteLine("You are in the shop.");
        Console.WriteLine($"You have {player.Gold}gold");
        Console.WriteLine("Choose an item to buy.");
        Console.WriteLine("(Click the number!)");

        Console.WriteLine("1 - Item1({price}gold)");
        Console.WriteLine("2 - Item2({price}gold)");
        Console.WriteLine("3 - Item3({price}gold)");
        Console.WriteLine("0 - Leave");
            
        char key = Console.ReadKey(true).KeyChar;
        switch (key)
        {
            case '1':
                break;
            case '2':
                break;
            case '3':
                break;
            case '0':
                return;
            default:
                Console.WriteLine("That is not a valid option.");
                break;
        }
    }
    
    public void Run(IPlayable player)
    {
        while (true)
        {
            BuyItem(player);
        }
    }
}