
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace TDLC.Infra.Entities.Configuration
{




    // Product
    internal class PublicacaoConfiguration : EntityTypeConfiguration<Publicacao>
    {
        public PublicacaoConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_publicacao");
            HasKey(x => x.id_publicacao);
            Property(x => x.id_publicacao).HasColumnName("id_publicacao").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CriadoPor).HasColumnName("criadopor").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.ModificadoPor).HasColumnName("modificadopor").IsRequired().IsUnicode(false).HasMaxLength(100);

            Property(x => x.DataPublicacao).HasColumnName("publicacao").IsRequired();

            Property(x => x.Arquivo).HasMaxLength(60);
            //FKS            
            HasRequired(a => a.TipoPublicacao).WithMany(b => b.Publicacoes).HasForeignKey(c => c.id_tipopublicacao); // FK_Publicacao_TipoPublicacao
                        

        }
    }

}

