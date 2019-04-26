
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace TDLC.Infra.Entities.Configuration
{




    // Product
    internal class TipoPublicacaoConfiguration : EntityTypeConfiguration<TipoPublicacao>
    {
        public TipoPublicacaoConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_tipopublicacao");
            HasKey(x => x.id_tipoPublicacao);
            Property(x => x.id_tipoPublicacao).HasColumnName("id_tipopublicacao").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasColumnName("nome").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.CaminhoImagemHeader).HasColumnName("imagemheader").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Nome_Tipo).HasColumnName("nometipo").IsOptional().IsUnicode(false).HasMaxLength(100);

        }
    }

}

