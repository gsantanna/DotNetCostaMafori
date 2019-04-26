using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using TDLC.Infra.Entities;
using System.Linq;

namespace TDLC.UI.Areas.Admin.Models.ViewModels
{
   public class EquipeViewmodel
    {


        public int id_equipe { get; set; }

        public int Ordem { get; set; }

        public Tipo_Equipe Tipo { get; set; }

        [Required]
        public string Nome { get; set; }
        public string FotoPopup { get; set; }
        public string FotoDestaque { get; set; }


        [DataType(DataType.EmailAddress)]
        [MaxLength(300, ErrorMessage ="Email inválido")]        
        [Display(Name =  "E-mail")]
        public string Email { get; set; }




        public string TipoDesc
        {
            get {
                return Tipo.ToString(); //EnumHelper<Tipo_Equipe>.GetDisplayValue(Tipo);
            }
        }




        public virtual List<ConteudoEquipeViewmodel> Conteudos { get; set; }



        public HttpPostedFileBase ArqFotoPopup { get; set; }
        public HttpPostedFileBase ArqFotoDestaque { get; set; }
        

    }

    public class ConteudoEquipeViewmodel
    {
        public int id_conteudoequipe { get; set; }
        public int id_equipe { get; set; }

        [AllowHtml]
        public string Chamada { get; set; }
        public string Cargo { get; set; }

        [AllowHtml]
        [Display(Name="Areas de Atuação")]
        public string AreasAtuacao { get; set; }

        [AllowHtml]

        [Display(Name = "Mini-Currículo")]
        public string Descricao { get; set; }
        public int id_linguagem { get; set; }




    }

}
