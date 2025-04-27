using Menu.NativeInterop;
using Menu.Parser;

namespace Menu.Execution;

public static class ScriptExecutor
{
    public static int Execute(IEnumerable<Instruction> script)
    {
        foreach (var instruction in script)
        {
            using EnvironmentScope scope = new(instruction.Environment);

            var code = Native.System(instruction.Command);

            if (code != 0)
            {
                Console.Error.WriteLine($"{instruction.Command} returned {code}.");
                return code;
            }
        }

        return 0;
    }
}