namespace Menu.Parser;

public class MenuItem
{
    public string Name { get; set; } = string.Empty;
    public IEnumerable<string> Script { get; set; } = [];
}