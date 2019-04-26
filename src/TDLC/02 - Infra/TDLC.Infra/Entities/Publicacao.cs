
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace TDLC.Infra.Entities
{
    [Table("tb_publicacao")]
    public class Publicacao
    {
        [Key]
        public int id_publicacao { get; set; }

        [StringLength(255)]
        public string URL { get; set; }

        public bool Destaque { get; set; }

        public bool DestaqueTopo { get; set; }

        public DateTime DataPublicacao { get; set; }

        public DateTime Criado { get; set; }

        public DateTime Modificado { get; set; }

        [StringLength(800)]
        public string CriadoPor { get; set; }

        [StringLength(800)]
        public string ModificadoPor { get; set; }

        public int? id_tipopublicacao { get; set; }


        public virtual List<ConteudoPublicacao> Conteudos { get; set; }

        public virtual TipoPublicacao TipoPublicacao { get; set; }


        public string Titulo
        {
            get
            {

                if (this.Conteudos == null || this.Conteudos.Count == 0)
                {
                    return "Sem título";
                }
                else
                {
                    return this.Conteudos[0].Titulo;
                }
            }

        }

        public bool ContemAnexo { get; set; }
        public string Arquivo { get; set; }



        public ConteudoPublicacao GetConteudo(string cultura)
        {
            if (this.Conteudos.Count < 1) return null;
            if (this.Conteudos.Count == 1) return this.Conteudos[0];

            ConteudoPublicacao primeiro = this.Conteudos.OrderBy(f => f.id_linguagem).First();

            ConteudoPublicacao cont = this.Conteudos.FirstOrDefault(f => f.Linguagem.Cultura.ToUpper() == cultura.ToUpper());

            if (cont == null) return this.Conteudos[0];


            var NaoConsiderar = new[] { "Titulo" };

            //percorre as propriedades do conteúdo pegando o valor do primeiro em caso de branco
            foreach (var prop in cont.GetType().GetProperties().Where(f => f.PropertyType.Name == "String"))
            {
                //caso a propriedade seja ignorada
                if (NaoConsiderar.Contains(prop.Name)) continue;

                string valor = Convert.ToString(Util.GetPropValue(cont, prop.Name));

                if (string.IsNullOrEmpty(valor))
                {
                    string valor_primeiro = Convert.ToString(Util.GetPropValue(primeiro, prop.Name));

                    Util.SetPropValue(cont, prop.Name, valor_primeiro);

                }

            }




            return cont;




        }



    }


    public class PublicacaoApi
    {
        public int id_publicacao { get; set; }
        public DateTime Criado { get; set; }
        public DateTime Modificado { get; set; }
        public string CriadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public string Tipo { get; set; }
        public string Titulo { get; set; }

        public DateTime DataPublicacao { get; set; }




    }




}
