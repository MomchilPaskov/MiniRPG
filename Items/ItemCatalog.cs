namespace MiniRPG;

public static class ItemCatalog
{
    public static readonly IReadOnlyList<Item> All = new List<Item>
    {
        new Item("Dark Knight Sword", "+0.7 damage multiplier", 300, p => p.AddStats(0, 0, 0, 0.7, 0)),
        new Item("Chain Chestplate", "+5 defense when defending", 250, p => p.AddStats(0, 5, 0, 0, 0)),
        new Item("Health Potion", "Heals 25hp", 50, p => p.Heal(25)),
        new Item("Fire Daggers", "+0.3 damage multiplier", 150, p => p.AddStats(0, 0, 0, 0.3, 0)),
        new Item("Book of Life", "+ 50 Max Health", 400, p => p.AddStats(0, 0, 0, 0, 50)),
    };
}