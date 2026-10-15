namespace MiniRPG;

public class EnemyFactory
{
    public Enemy Factory(IPlayable player)
    {
        if (player.RoundCount == 24)
        {
            var maker = EnemyCatalog.Boss;
            return maker();
        }

        Enemy enemy;
        
        if (player.RoundCount % 8 == 7)
        {
            var maker = EnemyCatalog.MiniBosses[Random.Shared.Next(EnemyCatalog.MiniBosses.Count)];
            enemy = maker();
        }
        else 
        {
            var maker = EnemyCatalog.BasicEnemies[Random.Shared.Next(EnemyCatalog.BasicEnemies.Count)];
            enemy = maker();
        }
        
        enemy.ScaleToTier(player.RoundCount / 8);
        return enemy;

    }
}