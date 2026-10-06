using System.Globalization;

namespace  MiniRPG;
class Program
{
    
    static void Main(string[] args)
    {
        GameSystem gs = new GameSystem();
        CombatSystem cs = new CombatSystem();
        Enemy ghost = new Ghost();
        
        Console.WriteLine("Welcome to MiniRPG!");

        string name = gs.SetName();
        Console.WriteLine($"Hello, {name}!");
        Character player = gs.SelectCharacter(name);
        
        cs.StartFight(player, ghost);
    }
}
