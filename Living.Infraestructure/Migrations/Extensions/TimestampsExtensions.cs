using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace Living.Infraestructure.Migrations.Extensions;
internal static class TimestampsExtensions
{
    internal static ICreateTableWithColumnOrSchemaOrDescriptionSyntax WithId(this ICreateTableWithColumnOrSchemaOrDescriptionSyntax fluent)
    {
        fluent.WithColumn("id").AsGuid().PrimaryKey().Identity();

        return fluent;
    }

    internal static ICreateTableColumnOptionOrWithColumnSyntax WithTimestamps(this ICreateTableColumnOptionOrWithColumnSyntax fluent)
    {
        fluent.WithColumn("created_at").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("last_updated_at").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("deleted_at").AsDateTime().Nullable();

        return fluent;
    }

    internal static ICreateTableColumnOptionOrWithColumnSyntax WithTimestamp(this ICreateTableColumnOptionOrWithColumnSyntax fluent)
    {
        fluent.WithColumn("created_at").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime);

        return fluent;
    }
}
