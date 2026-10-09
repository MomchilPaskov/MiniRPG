using System.ComponentModel.Design;

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
            IEncounter encounter = ChooseEncounter();
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
            Console.WriteLine("1 - Warrior,\n2 - Mage,\n3 - Archer");
            char key = Console.ReadKey().KeyChar;

            switch (key)
            {
                case '1':
                    Console.WriteLine("You selected warrior!");
                    return new Warrior(name, 100, 20);
                case '2':
                    Console.WriteLine("You selected warrior!");
                    return new Mage(name, 80, 30);
                case '3':
                    Console.WriteLine("You selected archer!");
                    return new Archer(name, 110, 10);
                default:
                    Console.WriteLine(key + "it's not a valid number");
                    break;
            }
        }
    }

    public IEncounter ChooseEncounter()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Where to go?");
            Console.WriteLine("(Click the number):");
            Console.WriteLine("1. Fight an enemy\n2. Forge your abilities.\n3. Shop");
        
            char key = Console.ReadKey().KeyChar;
            
            switch (key)
            {
                case '1':
                    return new BattleEncounter();
                case '2':
                    return new ForgeEncounter();
                case '3':
                    return new ShopEncounter();
                default:
                    Console.Clear();
                    Console.WriteLine(key + " is not a valid key!");
                    break;
            }
        }
        

        
    }
}