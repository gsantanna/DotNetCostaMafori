
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace TDLC.Infra.Entities.Configuration
{
    // Product
    internal class InstitucionalConfiguration : EntityTypeConfiguration<Institucional>
    {
        public InstitucionalConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_institucional");

            HasKey(x => x.id_institucional);     
                   
            Property(x => x.id_institucional).HasColumnName("id_institucional").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);                        

            Property(x => x.Nome).HasColumnName("nome").IsRequired().IsUnicode(false).HasMaxLength(100);

            Property(x => x.Arquivo).HasColumnName("arquivo").IsOptional().IsUnicode(false).HasMaxLength(100);            


        }
    }

}

