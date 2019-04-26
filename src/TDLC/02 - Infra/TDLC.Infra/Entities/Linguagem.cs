
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDLC.Infra.Entities
{
    
    public class Linguagem
    {

        [Key]
        public int id_linguagem { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Cultura { get; set; }

        [StringLength(20)]
        public string CodePage { get; set; }

        public virtual ICollection<ConteudoPublicacao>      ConteudosPublicacoes    { get; set; }
        public virtual ICollection<ConteudoEquipe>          ConteudosEquipe         { get; set; }
        public virtual ICollection<ConteudoAreaAtuacao>     ConteudosAreaAtuacao    { get; set; }

        public virtual ICollection<ConteudoInstitucional>   ConteudosInstitucional  { get; set; }



        public bool padrao { get; set; }

        [StringLength(1000)]
        public string Sitemap { get; set; }

    }

}
