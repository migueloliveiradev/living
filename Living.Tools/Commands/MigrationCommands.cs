using Living.Shared.Extensions;
using Living.Tools.Templates;
using System.Globalization;

namespace Living.Tools.Commands;
internal static class MigrationCommands
{
    internal static async Task NewMigration()
    {
        var name = AnsiConsole.Prompt(
            new TextPrompt<string>("What's the name of the migration?")
                .PromptStyle("green"));

        var date = DateTime.Now.ToString("yyyy_MM_dd_HH_mm", CultureInfo.CurrentCulture);

        var file_name = name.ToPascalCase();
        var path = Path.GetFullPath($"../../../../Living.Infraestructure/Migrations/{date}_{file_name}.cs");
        var template = ClassFilesTemplates.Migration(date, file_name);

        await File.WriteAllTextAsync(path, template);

        AnsiConsole.MarkupLine($"Migration created at [bold]{path}[/]\n\n");
    }

    internal static Task Up()
    {
        AnsiConsole.MarkupLine("[bold]Up[/]");

        return Task.CompletedTask;
    }

    internal static Task Down()
    {
        AnsiConsole.MarkupLine("[bold]Down[/]");

        return Task.CompletedTask;
    }
}
