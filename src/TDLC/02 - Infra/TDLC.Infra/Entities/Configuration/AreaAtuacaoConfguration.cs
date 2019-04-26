
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace TDLC.Infra.Entities.Configuration
{
    // Product
    internal class AreaAtuacaoConfiguration : EntityTypeConfiguration<AreaAtuacao>
    {
        public AreaAtuacaoConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_areaatuacao");

            HasKey(x => x.id_areatuacao);

            Property(x => x.id_areatuacao).HasColumnName("id_areaatuacao").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Imagem).HasColumnName("imagem").IsOptional().HasMaxLength(100);

            Property(x => x.id_pai).IsOptional();

            HasOptional(a => a.Pai).WithMany(b => b.Filhos).HasForeignKey(c => c.id_pai); // FK_Publicacao_TipoPublicacao






        }
    }

}

