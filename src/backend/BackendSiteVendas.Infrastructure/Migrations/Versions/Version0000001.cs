﻿using FluentMigrator;

namespace BackendSiteVendas.Infrastructure.Migrations.Versions;
    
[Migration((long)VersionsNumber.CreateUserTable, "Create user table")]
public class Version0000001 : Migration
{
    public override void Down()
    {
        throw new NotImplementedException();
    }

    public override void Up()
    {
        var table = VersionBase.InsertDefaultColumns(Create.Table("Users"));

        table
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Email").AsString(100).NotNullable()
            .WithColumn("Password").AsString(2000).NotNullable()
            .WithColumn("Phone").AsString(14).NotNullable();
    }
}
