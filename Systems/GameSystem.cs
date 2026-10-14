namespace MiniRPG;

public class GameSystem
{

    public void StartGame()
    {
        Console.Clear();
        Console.WriteLine("Welcome to MiniRPG!");

        string name = SetName();
        IPlayable player = SelectCharacter(name);

        while (player.IsAlive)
        {
            IEncounter? encounter = ChooseEncounter();
            if (encounter == null)
            {
                break;
            }
            encounter.Run(player);
        }
    }

    public string SetName()
    {
        Console.WriteLine("What is your name?");
        string? name = Console.ReadLine();
        return string.IsNullOrWhiteSpace(name) ? "Hero" : name.Trim();
        Console.WriteLine($"Hello, {name}!");
    }

    public Character SelectCharacter(string name)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Pick a character:(Click a number))");
            Console.WriteLine("1 - Warrior | 2 - Mage | 3 - Archer");
            char key = Console.ReadKey().KeyChar;

            switch (key)
            {
                case '1':
                    Console.WriteLine("You selected warrior!");
                    return new Warrior(name);
                case '2':
                    Console.WriteLine("You selected warrior!");
                    return new Mage(name);
                case '3':
                    Console.WriteLine("You selected archer!");
                    return new Archer(name);
                default:
                    Console.WriteLine(key + "it's not a valid number");
                    break;
            }
        }
    }

    public IEncounter? ChooseEncounter()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Where to go?");
            Console.WriteLine("(Click the number):");
            Console.WriteLine("1 - Fight an enemy | 2 - Forge your abilities. | 3 - Shop | 0 - Quit");
        
            char key = Console.ReadKey().KeyChar;
            
            switch (key)
            {
                case '1':
                    return new BattleEncounter();
                case '2':
                    return new ForgeEncounter();
                case '3':
                    return new ShopEncounter();
                case '0':
                    return null;
                default:
                    Console.Clear();
                    Console.WriteLine(key + " is not a valid key!");
                    break;
            }
        }
        

        
    }
}