namespace Menu.Parser;

public class Instruction
{
    public string Command { get; set; } = string.Empty;
    public Dictionary<string, string?> Environment { get; set; } = [];
}
