using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace Living.Infraestructure.Migrations.Extensions;
internal static class TimestampsExtensions
{
    public static ICreateTableColumnOptionOrWithColumnSyntax WithTimestamps(this ICreateTableColumnOptionOrWithColumnSyntax fluent)
    {
        fluent.WithColumn("created_at").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("last_updated_at").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("deleted_at").AsDateTime().Nullable();

        return fluent;
    }

    public static ICreateTableColumnOptionOrWithColumnSyntax WithTimestamp(this ICreateTableColumnOptionOrWithColumnSyntax fluent)
    {
        fluent.WithColumn("created_at").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime);

        return fluent;
    }
}
