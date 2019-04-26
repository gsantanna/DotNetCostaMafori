using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TDLC.UI.Models
{
    public class TrabalheConoscoVidemodel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "O arquivo é obrigatório")]        
        public HttpPostedFileBase arquivo { get; set; }



        public string IP { get; set; }
        public DateTime DataHora { get; set; }


    }
    public class ContatoFormViewmodel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(10, ErrorMessage = "Favor preencher o nome completo")]
        public string Nome { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [MinLength(8, ErrorMessage = "Favor preencher o nome completo")]
        [MaxLength(20, ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Favor preencher o assunto")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "Favor preencher a mensagem")]
        public string Mensagem { get; set; }


        public string IP { get; set; }
        public DateTime DataHora { get; set; }

    }
}