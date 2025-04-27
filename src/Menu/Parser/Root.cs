namespace Menu.Parser;

public class Root
{
    public AppMenu Menu { get; set; } = null!;
    public Dictionary<string, string?> Environment { get; set; } = [];
}