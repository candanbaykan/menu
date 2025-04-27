using ConsoleAppFramework;
using Menu.Execution;
using Menu.Parser;
using Spectre.Console;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Menu;

public class Commands
{
    /// <summary>
    /// Display a menu from a YAML file
    /// </summary>
    /// <param name="file">-f, The YAML file to display</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Exit code</returns>
    [Command("")]
    public async Task<int> Entrypoint(string file = "menu.yaml", CancellationToken ct = default)
    {
        var yaml = await File.ReadAllTextAsync(file, ct);

        var deserializer = new StaticDeserializerBuilder(new YamlStaticContext())
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();

        var root = deserializer.Deserialize<Root>(yaml);

        var item = await AnsiConsole.PromptAsync(
            new SelectionPrompt<MenuItem>()
                .Title(root.Menu.Title)
                .AddChoices(root.Menu.Items)
                .UseConverter(a => a.Name),
            ct);

        using EnvironmentScope scope = new(root.Environment);

        return ScriptExecutor.Execute(item.Script);
    }

    /// <summary>
    /// Initialize a new YAML file
    /// </summary>
    /// <param name="output">-o, Output path for the YAML file</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Exit code</returns>
    [Command("init")]
    public async Task<int> Init(string output = "menu.yaml", CancellationToken ct = default)
    {
        await File.WriteAllTextAsync(
            output,
            """
            menu:
              title: Menu
              items:
                - name: Single
                  script:
                    - command: set
                - name: Multiple
                  script:
                    - command: set
                      environment:
                        BAR: foo
                    - command: echo ------------------------------------------------------------------------------------
                    - command: set

            environment:
              FOO: foo
              BAR: bar

            """,
            ct);

        return 0;
    }
}