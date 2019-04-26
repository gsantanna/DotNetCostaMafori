namespace TDLC.Infra.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TDLC.Infra.TDLCDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TDLC.Infra.TDLCDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            context.Linguagens.AddOrUpdate(p => p.Nome,
                new Entities.Linguagem { Nome = "Portugês", CodePage = "1252", Cultura = "pt_BR", padrao = true },
                new Entities.Linguagem { Nome = "English", CodePage = "UTF-8", Cultura = "en_US", padrao = false }
                );


            context.TiposPublicacoes.AddOrUpdate(p => p.Nome,
                new Entities.TipoPublicacao { Nome = "Notícia", CaminhoImagemHeader = "header_news.jpg", Nome_Tipo = "noticia,noticias" },
                new Entities.TipoPublicacao { Nome = "Informativo", CaminhoImagemHeader = "header_news.jpg", Nome_Tipo = "informativo,informativos" },
                new Entities.TipoPublicacao { Nome = "Artigo", CaminhoImagemHeader = "header_news.jpg", Nome_Tipo = "artigo,artigos" }

                );


            List<Entities.ItemTabelaGenerica> tmp1 = new List<Entities.ItemTabelaGenerica>
            {
                new Entities.ItemTabelaGenerica { valor1 = "Dummy Record #1" , Criado = DateTime.Now, Modificado = DateTime.Now , CriadoPor = "Sytem", ModificadoPor = "System" },
                new Entities.ItemTabelaGenerica { valor1 = "Dummy Record #2" , Criado = DateTime.Now, Modificado = DateTime.Now , CriadoPor = "Sytem", ModificadoPor = "System" },
                new Entities.ItemTabelaGenerica { valor1 = "Dummy Record #3" , Criado = DateTime.Now, Modificado = DateTime.Now , CriadoPor = "Sytem", ModificadoPor = "System" }

            };


            context.Tabelas.AddOrUpdate(p => p.Nome,
                new Entities.TabelaGenerica
                {
                    Nome = "dummy",
                    Items = tmp1
                },
                new Entities.TabelaGenerica { Nome = "Instituicao Contemplada" },
                new Entities.TabelaGenerica { Nome = "Enderecos" }
                );





        }
    }
}

