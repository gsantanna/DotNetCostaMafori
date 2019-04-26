
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace TDLC.Infra.Entities.Configuration
{




    // Product
    internal class TabelaGenericaConfiguration : EntityTypeConfiguration<TabelaGenerica>
    {
        public TabelaGenericaConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_tabelagenerica");
            HasKey(x => x.id_tabelagenerica);
            //Property(x => x.id_tipoPublicacao).HasColumnName("id_tipopublicacao").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(800);

        }


        
    }


    internal class ItemTabelaGenericaConfiguration : EntityTypeConfiguration<ItemTabelaGenerica>
    {
        public ItemTabelaGenericaConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_itemtabelagenerica");
            HasKey(x => x.id_itemtabelagenerica);
            HasRequired(a => a.TabelaGenerica).WithMany(b => b.Items).HasForeignKey(c => c.id_tabelagenerica).WillCascadeOnDelete(true);
            
            Property(x => x.valor1).HasMaxLength(1000).HasColumnType("varchar").IsOptional();
            Property(x => x.valor2).HasMaxLength(1000).HasColumnType("varchar").IsOptional();
            Property(x => x.valor3).HasMaxLength(1000).HasColumnType("varchar").IsOptional();
            Property(x => x.valor4).HasMaxLength(1000).HasColumnType("varchar").IsOptional();
            Property(x => x.valor5).HasMaxLength(1000).HasColumnType("varchar").IsOptional();
            Property(x => x.valor6).HasMaxLength(1000).HasColumnType("varchar").IsOptional();
            Property(x => x.valor7).HasMaxLength(1000).HasColumnType("varchar").IsOptional();
            Property(x => x.valor8).HasMaxLength(1000).HasColumnType("varchar").IsOptional();
            Property(x => x.valor9).HasMaxLength(1000).HasColumnType("varchar").IsOptional();
            Property(x => x.valor10).HasMaxLength(1000).HasColumnType("varchar").IsOptional();

            Property(x => x.TextoLongo1).HasMaxLength(null).HasColumnType("text").IsOptional();
            Property(x => x.TextoLongo2).HasMaxLength(null).HasColumnType("text").IsOptional();
            Property(x => x.TextoLongo3).HasMaxLength(null).HasColumnType("text").IsOptional();

            Property(x => x.Arquivo1).HasMaxLength(64).IsOptional();
            Property(x => x.Arquivo2).HasMaxLength(64).IsOptional();

            Property(x => x.Data1).IsOptional();
            Property(x => x.Data2).IsOptional();
            Property(x => x.Data3).IsOptional();


            Property(x => x.Numero1).HasColumnType("int").IsOptional();
            Property(x => x.Numero2).HasColumnType("int").IsOptional();
            Property(x => x.Numero3).HasColumnType("int").IsOptional();



        }
    }

}


