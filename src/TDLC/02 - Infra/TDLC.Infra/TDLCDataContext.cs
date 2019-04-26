using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TDLC.Infra.Entities;
using TDLC.Infra.Entities.Configuration;
using TDLC.Infra.Entities.Configuration.TDLC.Infra.Entities.Configuration;

namespace TDLC.Infra
{
    public class TDLCDataContext : DbContext
    {

        public TDLCDataContext() : base("DefaultConnection")
        {
            //TODO : Veriry why we need this horrible hack to ensure Entities SQL dll is loaded.
            //source: http://robsneuron.blogspot.in/2013/11/entity-framework-upgrade-to-6.html
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            Database.Log = Console.Write;
        }




        public virtual DbSet<ConteudoPublicacao> ConteudosPublicacoes { get; set; }
        public virtual DbSet<Linguagem> Linguagens { get; set; }
        public virtual DbSet<Publicacao> Publicacoes { get; set; }
        public virtual DbSet<TipoPublicacao> TiposPublicacoes { get; set; }
        public virtual DbSet<Configuracao> Configuracoes { get; set; }
        public virtual DbSet<AreaAtuacao> AreasAtuacao { get; set; }
        
        
        public virtual DbSet<TabelaGenerica> Tabelas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.IsUnicode(false));
            modelBuilder.Properties<string>().Configure(p => p.IsOptional());



            modelBuilder.Configurations.Add(new LinguagemConfiguration());
            modelBuilder.Configurations.Add(new TipoPublicacaoConfiguration());
            modelBuilder.Configurations.Add(new PublicacaoConfiguration());
            modelBuilder.Configurations.Add(new ConteudoPublicacaoConfiguration());
            modelBuilder.Configurations.Add(new EquipeConfiguration());
            modelBuilder.Configurations.Add(new ConteudoEquipeConfiguration());
            modelBuilder.Configurations.Add(new AreaAtuacaoConfiguration());
            modelBuilder.Configurations.Add(new ConteudoAreaAtuacaoConfguration());


            modelBuilder.Configurations.Add(new InstitucionalConfiguration());
            modelBuilder.Configurations.Add(new ConteudoInstitucionalConfiguration());

            //modelBuilder.Configurations.Add(new LocalidadeConfiguration());
            //modelBuilder.Configurations.Add(new EscritorioConfiguration());


            modelBuilder.Configurations.Add(new TabelaGenericaConfiguration());
            modelBuilder.Configurations.Add(new ItemTabelaGenericaConfiguration());


        }
    }
}
