
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace TDLC.Infra.Entities.Configuration
{




    // Product
    internal class ConteudoEquipeConfiguration : EntityTypeConfiguration<ConteudoEquipe>
    {
        public ConteudoEquipeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_conteudoequipe");
            HasKey(x => x.id_conteudoequipe);
            Property(x => x.id_conteudoequipe).HasColumnName("id_conteudoequipe").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(x => x.Cargo).HasColumnName("cargo").IsOptional().HasMaxLength(255).HasColumnType("varchar").IsUnicode(false);
            Property(x => x.Descricao).HasColumnName("descricao").IsOptional().HasMaxLength(int.MaxValue).HasColumnType("text").IsUnicode(false);
            Property(x => x.AreasAtuacao).HasColumnName("areasatuacao").IsOptional().HasMaxLength(255).HasColumnType("varchar").IsUnicode(false);

            Property(x => x.Chamada).HasColumnName("chamada").IsOptional().HasMaxLength(8000).HasColumnType("text").IsUnicode(false);

            //FKS            
            HasRequired(a => a.Equipe).WithMany(b => b.Conteudos).HasForeignKey(f => f.id_equipe).WillCascadeOnDelete(true);

            HasRequired(a => a.Linguagem).WithMany(b => b.ConteudosEquipe).HasForeignKey(c => c.id_linguagem); 


        }
    }

}

