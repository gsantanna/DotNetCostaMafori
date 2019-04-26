
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace TDLC.Infra.Entities.Configuration
{




    // Product
    internal class ConteudoPublicacaoConfiguration : EntityTypeConfiguration<ConteudoPublicacao>
    {
        public ConteudoPublicacaoConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_conteudopublicacao");
            HasKey(x => x.id_conteudopublicacao);
            

            Property(x => x.id_conteudopublicacao).HasColumnName("id_conteudopublicacao").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
 
            Property(x => x.Titulo).HasColumnName("titulo").IsRequired().HasMaxLength(255).HasColumnType("varchar").IsUnicode(false);
            
            Property(x => x.Conteudo).HasColumnName("conteudo").IsOptional().HasColumnType("text").IsUnicode(false).HasMaxLength(null);


            //FKS            
            HasRequired(a => a.Publicacao).WithMany(b => b.Conteudos).HasForeignKey(f=> f.id_publicacao).WillCascadeOnDelete(true); //WithMany(b => b.Conteudos).HasForeignKey(c => c.id_publicacao).WillCascadeOnDelete(true);


            // FK_ConteudoPublicacao-->Publicacao
            HasRequired(a => a.Linguagem).WithMany(b => b.ConteudosPublicacoes).HasForeignKey(c => c.id_linguagem); //FK_ConteudoPublicacao-->Linguagem



    




        }
    }

}

