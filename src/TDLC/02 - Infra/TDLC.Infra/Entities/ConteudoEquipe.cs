using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLC.Infra.Entities
{
    [Table("tb_conteudoequipe")]
    public class ConteudoEquipe
    {
        [Key]
        public int id_conteudoequipe { get; set; }

        public string Chamada { get; set; }
        public string Cargo { get; set; }
        public string AreasAtuacao { get; set; }
        public string Descricao { get; set; }

        public int id_linguagem { get; set; }
        public virtual Linguagem Linguagem { get; set; }


        public int id_equipe { get; set; }
        public virtual Equipe Equipe { get; set; }

    }
}
