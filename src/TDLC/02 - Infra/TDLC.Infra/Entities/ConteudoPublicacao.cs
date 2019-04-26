

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace TDLC.Infra.Entities
{
    [Table("tb_ConteudoPublicacao")]
    public class ConteudoPublicacao
    {

        [Key]
        public int id_conteudopublicacao { get; set; }


        [StringLength(30)]
        public string Destaque_Categoria { get; set; }





        [StringLength(150)]
        public string Destaque_Titulo { get; set; }

        [StringLength(150)]
        public string Destaque_Titulo_Home_Topo { get; set; }

        [StringLength(150)]
        public string Destaque_Titulo_Home_Corpo { get; set; }


        [StringLength(300)]
        public string Destaque_Texto { get; set; }
















        [StringLength(255)]
        public string Titulo { get; set; }      


        public string Conteudo { get; set; }

        public int id_linguagem { get; set; }

        public int id_publicacao { get; set; }

        public virtual Linguagem Linguagem { get; set; }

        public virtual Publicacao Publicacao { get; set; }

        [StringLength(100)]
        public string Imagem1 { get; set; }
        [StringLength(100)]
        public string Imagem2 { get; set; }
        [StringLength(100)]
        public string Imagem3 { get; set; }
        [StringLength(100)]
        public string Imagem4 { get; set; }
        [StringLength(100)]
        public string Imagem5 { get; set; }
        [StringLength(100)]
        public string Imagem6 { get; set; }
        [StringLength(100)]
        public string Imagem7 { get; set; }
        [StringLength(100)]
        public string Imagem8 { get; set; }
        [StringLength(100)]
        public string Imagem9 { get; set; }
        [StringLength(100)]
        public string Imagem10 { get; set; }



        public DateTime Modificado
        {
            get { return Publicacao.Modificado; }
        }

        public DateTime DataPublicacao
        {
            get { return Publicacao.DataPublicacao;  }
        }

        public string Tipo
        {
            get
            {
                return Publicacao.TipoPublicacao.Nome_Tipo.Split(',')[0];

            }
        }


        public string URL { get { return Publicacao.URL; } }


    }
}
