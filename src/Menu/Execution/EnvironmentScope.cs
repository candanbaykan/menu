namespace Menu.Execution;

public class EnvironmentScope : IDisposable
{
    private readonly Dictionary<string, string?> _prev = [];

    public EnvironmentScope(Dictionary<string, string?> environment)
    {
        foreach (var (key, value) in environment)
        {
            _prev[key] = Environment.GetEnvironmentVariable(key);
            Environment.SetEnvironmentVariable(key, value);
        }
    }

    public void Dispose()
    {
        foreach (var (key, value) in _prev)
        {
            Environment.SetEnvironmentVariable(key, value);
        }
    }
}