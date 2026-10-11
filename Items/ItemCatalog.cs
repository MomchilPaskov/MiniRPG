namespace MiniRPG;

public static class ItemCatalog
{
    public static readonly IReadOnlyList<Item> All = new List<Item>
    {
        new Item("Sword", "+0.7 damage multiplier", 300, p => p.AddStats(0, 0, 0, 0.7)),
        new Item("Chestplate", "+5 defense when defending", 250, p => p.AddStats(0, 5, 0, 0)),
        new Item("Potion", "Heals 25hp", 50, p => p.Heal(25)),
    };
}