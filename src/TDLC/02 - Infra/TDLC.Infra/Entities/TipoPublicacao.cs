
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TDLC.Infra.Entities
{
    [Table("tb_tipopublicacao")]
    public class TipoPublicacao
    {
        [Key]
        public int id_tipoPublicacao { get; set; }

        public string CaminhoImagemHeader { get; set; }
                


        public string Nome { get; set; }        
        public string Nome_Tipo { get; set; }

        public virtual ICollection<Publicacao> Publicacoes { get; set; }

    }
}
