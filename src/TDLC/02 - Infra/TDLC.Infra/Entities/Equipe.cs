using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLC.Infra.Entities
{
    public enum Tipo_Equipe
    {
        ADVOGADO, SOCIO
    }

    [Table("tb_equipe")]
    public class Equipe
    {

        [Key]
        public int id_equipe { get; set; }

        public Tipo_Equipe Tipo { get; set; }

        public int Ordem { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string FotoPopup { get; set; }
        public string FotoDestaque { get; set; }

        public virtual List<ConteudoEquipe> Conteudos { get; set; }




    }
}
