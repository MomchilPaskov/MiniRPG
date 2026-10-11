namespace MiniRPG;

public class Item
{
    public string Name {get; } 
    public string Description {get; }
    public int Price {get; }
    public Action<IPlayable> Apply{get; }

    public Item(string name, string description, int price, Action<IPlayable> apply)
    {
        Name = name;
        Description = description;
        Price = price;
        Apply = apply;
    }
}