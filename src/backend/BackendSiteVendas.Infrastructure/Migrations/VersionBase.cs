using FluentMigrator.Builders.Create.Table;

namespace BackendSiteVendas.Infrastructure.Migrations;

public static class VersionBase
{
    public static ICreateTableWithColumnOrSchemaOrDescriptionSyntax InsertDefaultColumns(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
    {
        return (ICreateTableWithColumnOrSchemaOrDescriptionSyntax)table
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("CriationDate").AsDateTime().NotNullable();
    }
}