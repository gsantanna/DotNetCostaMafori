namespace TDLC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_areaatuacao",
                c => new
                    {
                        id_areaatuacao = c.Int(nullable: false, identity: true),
                        id_pai = c.Int(),
                        imagem = c.String(maxLength: 100, unicode: false),
                        Destaque = c.Boolean(nullable: false),
                        Ordem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_areaatuacao)
                .ForeignKey("dbo.tb_areaatuacao", t => t.id_pai)
                .Index(t => t.id_pai);
            
            CreateTable(
                "dbo.tb_conteudoareaatuacao",
                c => new
                    {
                        id_conteudoareatuacao = c.Int(nullable: false, identity: true),
                        id_areaatuacao = c.Int(nullable: false),
                        nome = c.String(nullable: false, maxLength: 255, unicode: false),
                        chamada = c.String(maxLength: 600, unicode: false),
                        Conteudo = c.String(maxLength: 8000, unicode: false),
                        id_linguagem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_conteudoareatuacao)
                .ForeignKey("dbo.tb_areaatuacao", t => t.id_areaatuacao, cascadeDelete: true)
                .ForeignKey("dbo.tb_linguagem", t => t.id_linguagem)
                .Index(t => t.id_areaatuacao)
                .Index(t => t.id_linguagem);
            
            CreateTable(
                "dbo.tb_linguagem",
                c => new
                    {
                        id_linguagem = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        cultura = c.String(nullable: false, maxLength: 30, unicode: false),
                        codepage = c.String(nullable: false, maxLength: 30, unicode: false),
                        padrao = c.Boolean(nullable: false),
                        Sitemap = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.id_linguagem);
            
            CreateTable(
                "dbo.tb_conteudoequipe",
                c => new
                    {
                        id_conteudoequipe = c.Int(nullable: false, identity: true),
                        chamada = c.String(unicode: false, storeType: "text"),
                        cargo = c.String(maxLength: 255, unicode: false),
                        areasatuacao = c.String(maxLength: 255, unicode: false),
                        descricao = c.String(unicode: false, storeType: "text"),
                        id_linguagem = c.Int(nullable: false),
                        id_equipe = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_conteudoequipe)
                .ForeignKey("dbo.tb_equipe", t => t.id_equipe, cascadeDelete: true)
                .ForeignKey("dbo.tb_linguagem", t => t.id_linguagem)
                .Index(t => t.id_linguagem)
                .Index(t => t.id_equipe);
            
            CreateTable(
                "dbo.tb_equipe",
                c => new
                    {
                        id_equipe = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                        Ordem = c.Int(nullable: false),
                        nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        email = c.String(maxLength: 300, unicode: false),
                        fotopopup = c.String(maxLength: 200, unicode: false),
                        fotodestaque = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.id_equipe);
            
            CreateTable(
                "dbo.tb_conteudoinstitucional",
                c => new
                    {
                        id_conteudoinstitucional = c.Int(nullable: false, identity: true),
                        id_institucional = c.Int(nullable: false),
                        id_linguagem = c.Int(nullable: false),
                        conteudo = c.String(nullable: false, unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.id_conteudoinstitucional)
                .ForeignKey("dbo.tb_institucional", t => t.id_institucional, cascadeDelete: true)
                .ForeignKey("dbo.tb_linguagem", t => t.id_linguagem)
                .Index(t => t.id_institucional)
                .Index(t => t.id_linguagem);
            
            CreateTable(
                "dbo.tb_institucional",
                c => new
                    {
                        id_institucional = c.Int(nullable: false, identity: true),
                        Area = c.String(maxLength: 8000, unicode: false),
                        nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        arquivo = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.id_institucional);
            
            CreateTable(
                "dbo.tb_conteudopublicacao",
                c => new
                    {
                        id_conteudopublicacao = c.Int(nullable: false, identity: true),
                        Destaque_Categoria = c.String(maxLength: 30, unicode: false),
                        Destaque_Titulo = c.String(maxLength: 150, unicode: false),
                        Destaque_Titulo_Home_Topo = c.String(maxLength: 150, unicode: false),
                        Destaque_Titulo_Home_Corpo = c.String(maxLength: 150, unicode: false),
                        Destaque_Texto = c.String(maxLength: 300, unicode: false),
                        titulo = c.String(nullable: false, maxLength: 255, unicode: false),
                        conteudo = c.String(unicode: false, storeType: "text"),
                        id_linguagem = c.Int(nullable: false),
                        id_publicacao = c.Int(nullable: false),
                        Imagem1 = c.String(maxLength: 100, unicode: false),
                        Imagem2 = c.String(maxLength: 100, unicode: false),
                        Imagem3 = c.String(maxLength: 100, unicode: false),
                        Imagem4 = c.String(maxLength: 100, unicode: false),
                        Imagem5 = c.String(maxLength: 100, unicode: false),
                        Imagem6 = c.String(maxLength: 100, unicode: false),
                        Imagem7 = c.String(maxLength: 100, unicode: false),
                        Imagem8 = c.String(maxLength: 100, unicode: false),
                        Imagem9 = c.String(maxLength: 100, unicode: false),
                        Imagem10 = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.id_conteudopublicacao)
                .ForeignKey("dbo.tb_linguagem", t => t.id_linguagem)
                .ForeignKey("dbo.tb_publicacao", t => t.id_publicacao, cascadeDelete: true)
                .Index(t => t.id_linguagem)
                .Index(t => t.id_publicacao);
            
            CreateTable(
                "dbo.tb_publicacao",
                c => new
                    {
                        id_publicacao = c.Int(nullable: false, identity: true),
                        URL = c.String(maxLength: 255, unicode: false),
                        Destaque = c.Boolean(nullable: false),
                        DestaqueTopo = c.Boolean(nullable: false),
                        publicacao = c.DateTime(nullable: false),
                        Criado = c.DateTime(nullable: false),
                        Modificado = c.DateTime(nullable: false),
                        criadopor = c.String(nullable: false, maxLength: 100, unicode: false),
                        modificadopor = c.String(nullable: false, maxLength: 100, unicode: false),
                        id_tipopublicacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_publicacao)
                .ForeignKey("dbo.tb_tipopublicacao", t => t.id_tipopublicacao)
                .Index(t => t.id_tipopublicacao);
            
            CreateTable(
                "dbo.tb_tipopublicacao",
                c => new
                    {
                        id_tipopublicacao = c.Int(nullable: false, identity: true),
                        imagemheader = c.String(maxLength: 200, unicode: false),
                        nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        nometipo = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.id_tipopublicacao);
            
            CreateTable(
                "dbo.Configuracao",
                c => new
                    {
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Valor = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Nome);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_areaatuacao", "id_pai", "dbo.tb_areaatuacao");
            DropForeignKey("dbo.tb_conteudoareaatuacao", "id_linguagem", "dbo.tb_linguagem");
            DropForeignKey("dbo.tb_conteudopublicacao", "id_publicacao", "dbo.tb_publicacao");
            DropForeignKey("dbo.tb_publicacao", "id_tipopublicacao", "dbo.tb_tipopublicacao");
            DropForeignKey("dbo.tb_conteudopublicacao", "id_linguagem", "dbo.tb_linguagem");
            DropForeignKey("dbo.tb_conteudoinstitucional", "id_linguagem", "dbo.tb_linguagem");
            DropForeignKey("dbo.tb_conteudoinstitucional", "id_institucional", "dbo.tb_institucional");
            DropForeignKey("dbo.tb_conteudoequipe", "id_linguagem", "dbo.tb_linguagem");
            DropForeignKey("dbo.tb_conteudoequipe", "id_equipe", "dbo.tb_equipe");
            DropForeignKey("dbo.tb_conteudoareaatuacao", "id_areaatuacao", "dbo.tb_areaatuacao");
            DropIndex("dbo.tb_publicacao", new[] { "id_tipopublicacao" });
            DropIndex("dbo.tb_conteudopublicacao", new[] { "id_publicacao" });
            DropIndex("dbo.tb_conteudopublicacao", new[] { "id_linguagem" });
            DropIndex("dbo.tb_conteudoinstitucional", new[] { "id_linguagem" });
            DropIndex("dbo.tb_conteudoinstitucional", new[] { "id_institucional" });
            DropIndex("dbo.tb_conteudoequipe", new[] { "id_equipe" });
            DropIndex("dbo.tb_conteudoequipe", new[] { "id_linguagem" });
            DropIndex("dbo.tb_conteudoareaatuacao", new[] { "id_linguagem" });
            DropIndex("dbo.tb_conteudoareaatuacao", new[] { "id_areaatuacao" });
            DropIndex("dbo.tb_areaatuacao", new[] { "id_pai" });
            DropTable("dbo.Configuracao");
            DropTable("dbo.tb_tipopublicacao");
            DropTable("dbo.tb_publicacao");
            DropTable("dbo.tb_conteudopublicacao");
            DropTable("dbo.tb_institucional");
            DropTable("dbo.tb_conteudoinstitucional");
            DropTable("dbo.tb_equipe");
            DropTable("dbo.tb_conteudoequipe");
            DropTable("dbo.tb_linguagem");
            DropTable("dbo.tb_conteudoareaatuacao");
            DropTable("dbo.tb_areaatuacao");
        }
    }
}
