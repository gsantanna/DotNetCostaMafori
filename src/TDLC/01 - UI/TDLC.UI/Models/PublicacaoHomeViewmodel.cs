using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDLC.UI.Models
{
    public class PublicacaoApiViewmodel
    {
        public int id_publicacao { get; set; }

        [Display(Name = "Tipo de Publicação")]
        public string Tipo { get; set; }


        [Display(Name = "Tipo de Publicação")]
        public int id_tipopublicacao { get; set; }

        [Display(Name = "URL Amigável")]
        [MaxLength(255)]
        [Required(ErrorMessage = "O URL obrigatório. ex: titulo-da-publicacao  ")]
        public string URL { get; set; }


        [Display(Name = "Título")]
        public string Titulo { get; set; }

        public DateTime Criado { get; set; }

        [Display(Name = "Data Atualização")]
        public DateTime Modificado { get; set; }

        public string CriadoPor { get; set; }

        [Display(Name = "Data Publicação")]
        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Favor inserir uma data válida")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime DataPublicacao { get; set; }

        [Display(Name = "Modificado Por")]
        public string ModificadoPor { get; set; }


    }
}
