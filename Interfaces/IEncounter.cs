namespace MiniRPG;

public interface IEncounter
{
    string Name { get; }
    string Description { get; }
    void Run(IPlayable player);
}