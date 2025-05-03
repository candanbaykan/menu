namespace Menu.Parser;

public class Root
{
    public string? Title { get; set; }
    public IEnumerable<MenuItem> Menu { get; set; } = [];
}