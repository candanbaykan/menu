using ConsoleAppFramework;
using Menu;

var app = ConsoleApp.Create();

app.Add<Commands>();

await app.RunAsync(args);