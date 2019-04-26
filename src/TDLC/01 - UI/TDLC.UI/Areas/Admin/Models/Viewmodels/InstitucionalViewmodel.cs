


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using TDLC.Infra.Entities;

namespace TDLC.UI.Areas.Admin.Models.ViewModels
{
    public class InstitucionalViewmodel
    {
        public int id_institucional { get; set; }

        [Required(ErrorMessage ="O campo área é obrigatório")]
        [MaxLength(100, ErrorMessage = "Valor muito grande, utilizar no máximo 100 caracteres")]
        [Display(Name ="Área")]
        public string Area { get; set; }

        [Display(Name ="Nome do conteúdo")]
        [MaxLength(100, ErrorMessage ="Nome muito grande, utilizar no máximo 100 caracteres")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Descrição do conteúdo")]
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [MaxLength(300, ErrorMessage = "Valor muito grande, utilizar no máximo 300 caracteres")]
        public string Descricao { get; set; }
        

        public string Arquivo { get; set; }
        public List<ConteudoInstitucionalViewmodel> Conteudos { get; set; }

        public HttpPostedFileBase ArquivoEnviado { get; set; }          


    }

    public class ConteudoInstitucionalViewmodel
    {
        public int id_conteudoinstitucional { get; set; }
        public int id_institucional { get; set; }
        public int id_linguagem { get; set; }


        [AllowHtml]
        [Required(ErrorMessage ="Este campo é obrigatório. Quando só a imagem for necessária ele será descrição da imagem. (alt) ")]
        [Display(Name = "Conteúdo")]
        public string Conteudo { get; set; }

    }

}