
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace TDLC.Infra.Entities.Configuration
{
    // Product
    internal class ConteudoAreaAtuacaoConfguration : EntityTypeConfiguration<ConteudoAreaAtuacao>
    {
        public ConteudoAreaAtuacaoConfguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_conteudoareaatuacao");

            HasKey(x => x.id_conteudoareatuacao);

            Property(x => x.id_conteudoareatuacao).HasColumnName("id_conteudoareatuacao").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasColumnName("nome").IsRequired().HasMaxLength(255).HasColumnType("varchar").IsUnicode(false);

            Property(x => x.Chamada).HasColumnName("chamada").IsOptional().HasMaxLength(600).HasColumnType("varchar").IsUnicode(false);                        

            //FKS            
            HasRequired(a => a.AreaAtuacao).WithMany(b => b.Conteudos).HasForeignKey(f=> f.id_areaatuacao).WillCascadeOnDelete(true); //WithMany(b => b.Conteudos).HasForeignKey(c => c.id_publicacao).WillCascadeOnDelete(true);

            // FK_ConteudoPublicacao-->Publicacao
            HasRequired(a => a.Linguagem).WithMany(b => b.ConteudosAreaAtuacao).HasForeignKey(c => c.id_linguagem); //FK_ConteudoPublicacao-->Linguagem
            

        }
    }

}

