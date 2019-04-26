

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using TDLC.Infra.Entities;

namespace TDLC.UI.Areas.Admin.Models.ViewModels
{
    public class AreaAtuacaoViewmodel
    {

        public int id_areatuacao { get; set; }

        [Display(Name ="Área Pai")]
        public int? id_pai { get; set; }

        public string Imagem { get; set; }

        public bool Destaque { get; set; }

        public  List<ConteudoAreaAtuacaoViewmodel> Conteudos { get; set; }

        public string Nome { get; set; }

        [DefaultValue(0)]
        public int Ordem { get; set; }

        public string NomePai { get; set; }


       public  HttpPostedFileBase ArqImagem { get; set; }


        public List<AreaAtuacaoViewmodel> Filhos { get; set; }


    }


    public class ConteudoAreaAtuacaoViewmodel
    {
        public int id_conteudoareatuacao { get; set; }

        public int id_areaatuacao { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório em todas as linguas")]
        public string Nome { get; set; }

        public string Chamada { get; set; }
        
        public string Conteudo { get; set; }

        public int id_linguagem { get; set; }

    }




}