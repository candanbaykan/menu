using Menu.NativeInterop;
using Spectre.Console;

namespace Menu.Execution;

public static class ScriptExecutor
{
    public static int Execute(IEnumerable<string> script)
    {
        foreach (var command in script)
        {
            var code = Native.System(command);

            if (code != 0)
            {
                AnsiConsole.MarkupLineInterpolated($"[red]Error:[/] {command} returned {code}.");
                return code;
            }
        }

        return 0;
    }
}