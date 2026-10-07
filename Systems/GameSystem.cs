using System.ComponentModel.Design;

namespace MiniRPG;

public class GameSystem
{

    public void StartGame()
    {
        Console.Clear();
        Console.WriteLine("Welcome to MiniRPG!");
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
        bool isSelected = false;
        int characterChoise;
        do
        {
            Console.WriteLine("Pick a character:(Choose a number!)");

            Console.WriteLine("1 - Warrior,\n2 - Mage,\n3 - Archer");
            if (int.TryParse(Console.ReadLine(), out characterChoise))
            {
                if (characterChoise <= 3 && characterChoise > 0)
                    isSelected = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid number!");
            }
        } while (!isSelected);


        Character selectedCharacter;
        
        switch (characterChoise)
        {
            case 1:
                selectedCharacter = new Warrior(name, 100, 20);
                Console.WriteLine("You selected warrior!");
                break;
            case 2:
                selectedCharacter = new Mage(name, 80, 30);
                Console.WriteLine("You selected mage!");
                break;
            case 3:
                selectedCharacter = new Archer(name, 110, 10);
                Console.WriteLine("You selected archer!");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return selectedCharacter;
    }
    
}