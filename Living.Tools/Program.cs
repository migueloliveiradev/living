using Living.Tools.Commands;

namespace Living.Tools;

#pragma warning disable S2190

public static class Program
{
    public static async Task Main()
    {
        while (true)
            await ShowMenu();
    }

    private static async Task ShowMenu()
    {
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Living Tools")
                .PageSize(10)
                .AddChoiceGroup("Migrations", commands.Keys));

        AnsiConsole.Clear();

        if (commands.TryGetValue(option, out var command))
            await command();
    }

    private readonly static Dictionary<string, Func<Task>> commands = new()
    {
        ["New Migration"] = MigrationCommands.NewMigration,
        ["Up"] = MigrationCommands.Up,
        ["Down"] = MigrationCommands.Down,
    };
}