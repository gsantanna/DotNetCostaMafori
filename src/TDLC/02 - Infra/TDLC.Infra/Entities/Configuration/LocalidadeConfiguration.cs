using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLC.Infra.Entities.Configuration
{
    namespace TDLC.Infra.Entities.Configuration
    {
        // Product
        internal class LocalidadeConfiguration : EntityTypeConfiguration<Localidade>
        {
            public LocalidadeConfiguration(string schemaName = "dbo")
            {
                HasKey(x => x.id_localidade);
                ToTable(schemaName + ".tb_localidade");

                Property(x => x.Abreviacao).HasColumnType("varchar").HasMaxLength(4).IsRequired();
                Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            }
        }


        internal class EscritorioConfiguration : EntityTypeConfiguration<Escritorio>
        {
            public EscritorioConfiguration(string schemaName = "dbo")
            {
                HasKey(x => x.id_escritorio);

                ToTable(schemaName + ".tb_escritorio");
                Property(x => x.Mapa).HasColumnType("varchar").HasMaxLength(8000).IsOptional();
                Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(300).IsOptional();
                Property(x => x.EnderecoL1).HasColumnType("varchar").HasMaxLength(100).IsOptional();
                Property(x => x.EnderecoL2).HasColumnType("varchar").HasMaxLength(100).IsOptional();
                Property(x => x.Telefone).HasColumnType("varchar").HasMaxLength(100).IsOptional();
                HasRequired(a => a.Localidade).WithMany(b => b.Escritorios).HasForeignKey(c => c.id_localidade).WillCascadeOnDelete(true);


            }
        }

    }
}