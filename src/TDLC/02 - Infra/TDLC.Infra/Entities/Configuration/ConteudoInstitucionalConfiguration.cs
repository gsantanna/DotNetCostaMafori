
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace TDLC.Infra.Entities.Configuration
{
    // Product
    internal class ConteudoInstitucionalConfiguration : EntityTypeConfiguration<ConteudoInstitucional>
    {
        public ConteudoInstitucionalConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_conteudoinstitucional");

            HasKey(x => x.id_conteudoinstitucional);     
                   
            Property(x => x.id_conteudoinstitucional).HasColumnName("id_conteudoinstitucional").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Conteudo).HasColumnName("conteudo").IsRequired().IsUnicode(false).HasColumnType("text");


            //FKS            
            HasRequired(a => a.Institucional).WithMany(b => b.Conteudos).HasForeignKey(f => f.id_institucional).WillCascadeOnDelete(true); //WithMany(b => b.Conteudos).HasForeignKey(c => c.id_publicacao).WillCascadeOnDelete(true);


            HasRequired(a => a.Linguagem).WithMany(b => b.ConteudosInstitucional).HasForeignKey(c => c.id_linguagem); //FK_ConteudoPublicacao-->Linguagem


        }
    }

}

