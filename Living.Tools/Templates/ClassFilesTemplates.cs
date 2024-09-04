namespace Living.Tools.Templates;
internal static class ClassFilesTemplates
{
    internal static string Migration(string version, string description)
    {
        return $@"namespace Living.Infraestructure.Migrations;

[Migration({version}, ""{description}"")]
public class {description} : Migration
{{
    public override void Up()
    {{
        
    }}

    public override void Down()
    {{
                
    }}
}}";
    }
}
