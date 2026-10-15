namespace MiniRPG;

public static class EnemyCatalog
{
    public static readonly IReadOnlyList<Func<Enemy>> BasicEnemies = new List<Func<Enemy>>
    {
        () => new Enemy("Goblin", 60, 15),
        () => new Enemy("Ghost", 20, 0),
        () => new Enemy("Zombie", 80, 10),
    };
    public static readonly IReadOnlyList<Func<Enemy>> MiniBosses = new List<Func<Enemy>>
    {
        () => new Enemy("DarkKnight", 200, 20),
        () => new Enemy("BlackHydra", 250, 35),
        () => new Enemy("PhantomBear", 230, 30),
    };

    public static readonly Func<Enemy> Boss = () => new Enemy("The Evil Owl", 1500, 80);
}