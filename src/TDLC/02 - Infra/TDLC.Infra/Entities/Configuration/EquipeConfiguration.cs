
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace TDLC.Infra.Entities.Configuration
{
    // Product
    internal class EquipeConfiguration : EntityTypeConfiguration<Equipe>
    {

        public EquipeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tb_equipe");
            HasKey(x => x.id_equipe );
            Property(x => x.Nome).HasColumnName("nome").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.FotoPopup).HasColumnName("fotopopup").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.FotoDestaque).HasColumnName("fotodestaque").IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Email).HasColumnName("email").IsOptional().IsUnicode(false).HasMaxLength(300);

        }

    }
}
