using FluentMigrator;

namespace BackendSiteVendas.Infrastructure.Migrations.Versions;
    
[Migration((long)VersionsNumber.CriarTabelaUsuario, "Cria tabela Usuario")]
public class Version0000001 : Migration
{
    public override void Down()
    {
        throw new NotImplementedException();
    }

    public override void Up()
    {
        var table = VersionBase.InsertDefaultColumns(Create.Table("Usuario"));

        table
            .WithColumn("Nome").AsString(100).NotNullable()
            .WithColumn("Email").AsString(100).NotNullable()
            .WithColumn("Senha").AsString(2000).NotNullable()
            .WithColumn("Telefone").AsString(14).NotNullable();
    }
}
