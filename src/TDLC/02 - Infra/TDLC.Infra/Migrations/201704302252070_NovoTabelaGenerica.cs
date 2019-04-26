namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovoTabelaGenerica : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_escritorio", "id_localidade", "dbo.tb_localidade");
            DropIndex("dbo.tb_escritorio", new[] { "id_localidade" });
            CreateTable(
                "dbo.tb_tabelagenerica",
                c => new
                    {
                        id_tabelagenerica = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 800, unicode: false),
                    })
                .PrimaryKey(t => t.id_tabelagenerica);
            
            CreateTable(
                "dbo.tb_itemtabelagenerica",
                c => new
                    {
                        id_itemtabelagenerica = c.Int(nullable: false, identity: true),
                        id_tabelagenerica = c.Int(nullable: false),
                        valor1 = c.String(maxLength: 1000, unicode: false),
                        valor2 = c.String(maxLength: 1000, unicode: false),
                        valor3 = c.String(maxLength: 1000, unicode: false),
                        valor4 = c.String(maxLength: 1000, unicode: false),
                        valor5 = c.String(maxLength: 1000, unicode: false),
                        valor6 = c.String(maxLength: 1000, unicode: false),
                        valor7 = c.String(maxLength: 1000, unicode: false),
                        valor8 = c.String(maxLength: 1000, unicode: false),
                        valor9 = c.String(maxLength: 1000, unicode: false),
                        valor10 = c.String(maxLength: 1000, unicode: false),
                        Numero1 = c.Int(),
                        Numero2 = c.Int(),
                        Numero3 = c.Int(),
                        Numero4 = c.Int(),
                        Numero5 = c.Int(),
                        Data1 = c.DateTime(),
                        Data2 = c.DateTime(),
                        Data3 = c.DateTime(),
                        Data4 = c.DateTime(),
                        Data5 = c.DateTime(),
                        TextoLongo1 = c.String(unicode: false, storeType: "text"),
                        TextoLongo2 = c.String(unicode: false, storeType: "text"),
                        TextoLongo3 = c.String(unicode: false, storeType: "text"),
                        Arquivo1 = c.String(maxLength: 64, unicode: false),
                        Arquivo2 = c.String(maxLength: 64, unicode: false),
                        CriadoPor = c.String(maxLength: 8000, unicode: false),
                        ModificadoPor = c.String(maxLength: 8000, unicode: false),
                        Criado = c.DateTime(nullable: false),
                        Modificado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_itemtabelagenerica)
                .ForeignKey("dbo.tb_tabelagenerica", t => t.id_tabelagenerica, cascadeDelete: true)
                .Index(t => t.id_tabelagenerica);
            
            DropTable("dbo.tb_escritorio");
            DropTable("dbo.tb_localidade");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.id_escritorio);
            
            DropForeignKey("dbo.tb_itemtabelagenerica", "id_tabelagenerica", "dbo.tb_tabelagenerica");
            DropIndex("dbo.tb_itemtabelagenerica", new[] { "id_tabelagenerica" });
            DropTable("dbo.tb_itemtabelagenerica");
            DropTable("dbo.tb_tabelagenerica");
            CreateIndex("dbo.tb_escritorio", "id_localidade");
            AddForeignKey("dbo.tb_escritorio", "id_localidade", "dbo.tb_localidade", "id_localidade", cascadeDelete: true);
        }
    }
}
