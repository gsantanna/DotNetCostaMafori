namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Escritorio1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_escritorio",
                c => new
                    {
                        id_escritorio = c.Int(nullable: false, identity: true),
                        id_localidade = c.Int(nullable: false),
                        Ordem = c.Int(nullable: false),
                        Nome = c.String(maxLength: 300, unicode: false),
                        Telefone = c.String(maxLength: 100, unicode: false),
                        EnderecoL1 = c.String(maxLength: 100, unicode: false),
                        EnderecoL2 = c.String(maxLength: 100, unicode: false),
                        Mapa = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.id_escritorio)
                .ForeignKey("dbo.tb_localidade", t => t.id_localidade, cascadeDelete: true)
                .Index(t => t.id_localidade);
            
            CreateTable(
                "dbo.tb_localidade",
                c => new
                    {
                        id_localidade = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Abreviacao = c.String(nullable: false, maxLength: 4, unicode: false),
                        Ordem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_localidade);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_escritorio", "id_localidade", "dbo.tb_localidade");
            DropIndex("dbo.tb_escritorio", new[] { "id_localidade" });
            DropTable("dbo.tb_localidade");
            DropTable("dbo.tb_escritorio");
        }
    }
}
