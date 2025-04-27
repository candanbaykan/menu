namespace Menu.Parser;

public class AppMenu
{
    public string? Title { get; set; }
    public IEnumerable<MenuItem> Items { get; set; } = [];
}