
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

    using System.ComponentModel.DataAnnotations;

namespace TDLC.Infra.Entities
{

    public class AreaAtuacao
    {
        public int id_areatuacao { get; set; }


        public virtual AreaAtuacao Pai { get; set; }


        public int? id_pai { get; set; }

        public virtual List<AreaAtuacao> Filhos { get; set; }



        public string Imagem { get; set; }
        public bool Destaque { get; set; }
        public virtual List<ConteudoAreaAtuacao> Conteudos { get; set; }
        public int Ordem { get; set; }

        public string Nome
        {
            get
            {

                if (this.Conteudos == null || this.Conteudos.Count == 0)
                {
                    return "Sem nome";
                }
                else
                {
                    return this.Conteudos[0].Nome;
                }
            }

        }

        public string NomePai
        {
            get
            {
                if (this.Pai == null)
                {
                    return "TOPO";
                }
                else
                {
                    return Pai.Nome;
                }
            }
        }




    }


}
