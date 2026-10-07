using System.Globalization;

namespace  MiniRPG;
class Program
{
    
    static void Main(string[] args)
    {
        GameSystem gs = new GameSystem();
        CombatSystem cs = new CombatSystem();
        EnemyFactory ef = new EnemyFactory();

        Enemy enemy = ef.Factory();

        gs.StartGame();
        string name = gs.SetName();
        Character player = gs.SelectCharacter(name);
        
        cs.StartFight(player, enemy);
    }
}
