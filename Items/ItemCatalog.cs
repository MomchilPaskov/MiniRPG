namespace MiniRPG;

public static class ItemCatalog
{
    public static readonly IReadOnlyList<Item> All = new List<Item>
    {
        new Item("Dark Knight Sword", "+0.6 damage multiplier", 500, p => p.AddStats(0, 0, 0, 0.6, 0)),
        new Item("Chain Chestplate", "+15 defense when defending", 450, p => p.AddStats(0, 15, 0, 0, 0)),
        new Item("Health Potion", "Heals 25hp", 50, p => p.Heal(25)),
        new Item("Health Potion", "Heals 25hp", 50, p => p.Heal(25)),
        new Item("Health Potion", "Heals 25hp", 50, p => p.Heal(25)),
        new Item("Health Potion", "Heals 25hp", 50, p => p.Heal(25)),
        new Item("Health Potion", "Heals 25hp", 50, p => p.Heal(25)),
        new Item("Fire Daggers", "+0.5 damage multiplier", 450, p => p.AddStats(0, 0, 0, 0.5, 0)),
        new Item("Book of Life", "+150 Max Health & Heals 150 HP", 600, p => { p.AddStats(0, 0, 0, 0, 150); p.Heal(150); }),
        new Item("Bulk Potion", "+0.5 damage multiplier", 500, p => p.AddStats(0, 0, 0, 0.5, 0)),
        new Item("Owl's feather", "+0.75 damage multiplier", 400, p => p.AddStats(0, 0, 0, 0.75, 0)),
        new Item("Wooden Buckler", "+8 Defend Power", 350, p => p.AddStats(0, 8, 0, 0, 0)),
        new Item("Sharpening Stone", "+10 Base Attack Power", 350, p =>  p.AddStats(10, 0, 0, 0, 0)),
        new Item("Knight's Greatshield", "+30 Defend Power & +50 Max Health", 600, p => p.AddStats(0, 30, 0, 0, 50)),
        new Item("Warrior's Ring", "+15 Base Attack Power & +0.20 Damage Multiplier", 500, p => p.AddStats(15, 0, 0, 0.2, 0)),
        new Item("Berserker's Axe", "+40 Base Attack Power & +0.30 Damage Multiplier", 900, p => p.AddStats(40, 0, 0, 0.3, 0)),
        new Item("Aegis Armor", "+35 Defend Power & +200 Max Health", 1000, p => { p.AddStats(0, 35, 0, 0, 200); p.Heal(200); }),
        new Item("Elixir of Ultimate Power", "+0.80 Damage Multiplier & Heals 100 HP", 700, p => { p.AddStats(0, 0, 0, 0.80, 0); p.Heal(100); }),
    };
}