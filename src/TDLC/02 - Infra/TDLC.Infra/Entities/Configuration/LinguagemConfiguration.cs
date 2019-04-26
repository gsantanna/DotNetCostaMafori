
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace TDLC.Infra.Entities.Configuration
{




    // Product
    internal class LinguagemConfiguration : EntityTypeConfiguration<Linguagem>
    {
        public LinguagemConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_linguagem");
            HasKey(x => x.id_linguagem);
            Property(x => x.id_linguagem).HasColumnName("id_linguagem").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasColumnName("nome").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.CodePage).HasColumnName("codepage").IsRequired().IsUnicode(false).HasMaxLength(30);
            Property(x => x.Cultura).HasColumnName("cultura").IsRequired().IsUnicode(false).HasMaxLength(30);



        }
    }

}

