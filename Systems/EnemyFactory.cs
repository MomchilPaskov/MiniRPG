namespace MiniRPG;

public class EnemyFactory
{
    public Enemy Factory()
    {
        Enemy[] enemies = {new Ghost(), new Goblin(), new Zombie()};
        Enemy enemy = enemies[Random.Shared.Next(enemies.Length)];
        return enemy;
    }
}