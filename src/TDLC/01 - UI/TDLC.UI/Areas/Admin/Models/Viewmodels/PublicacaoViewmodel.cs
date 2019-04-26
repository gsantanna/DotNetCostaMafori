using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace TDLC.UI.Areas.Admin.Models.ViewModels
{

    public class PublicacaoViewmodel
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


        [AllowHtml]
        [Display(Name = "Destaque Topo")]
        public bool Destaque { get; set; }


        [Display(Name = "Destaque no topo home")]
        public bool DestaqueTopo { get; set; }


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

        public string CaminhoImagemHeader { get; set; }

        public List<ConteudoPublicacaoViewmodel> Conteudos { get; set; }

        public int id_mes => this.DataPublicacao.Month;
        public int id_ano => this.DataPublicacao.Year;


        [Display(Name = "Adicionar arquivo PDF")]
        public bool ContemAnexo { get; set; }

        public string Arquivo { get; set; }

        public HttpPostedFileBase ArquivoEnviado { get; set; }



    }


    public class ConteudoPublicacaoViewmodel
    {
        [Key]
        public int id_conteudopublicacao { get; set; }


        [AllowHtml]
        [MaxLength(150, ErrorMessage = "O limite máximo de caracteres é {1}")]
        [Display(Name = "Título do destaque")]
        public string Titulo { get; set; }





        [AllowHtml]
        [Display(Name = "Categoria destaque")]
        [MaxLength(30, ErrorMessage = "O limite máximo de caracteres é {1} ")]
        public string Destaque_Categoria { get; set; }

        [AllowHtml]
        [MaxLength(150, ErrorMessage = "O limite máximo de caracteres é {1}")]
        [Display(Name = "Título destaque interna")]
        public string Destaque_Titulo { get; set; }


        [AllowHtml]
        [MaxLength(35, ErrorMessage = "O limite máximo de caracteres é {1}")]
        [Display(Name = "Título destaque home topo")]
        public string Destaque_Titulo_Home_Topo { get; set; }


        [AllowHtml]
        [MaxLength(45, ErrorMessage = "O limite máximo de caracteres é {1}")]
        [Display(Name = "Título destaque home corpo")]
        public string Destaque_Titulo_Home_Corpo { get; set; }


        [AllowHtml]
        [MaxLength(250, ErrorMessage = "O limite máximo de caracteres é {1}")]
        [Display(Name = "Descrição destaque")]
        public string Destaque_Texto { get; set; }

        public DateTime Modificado { get; set; }

        public DateTime DataPublicacao { get; set; }



        [AllowHtml]
        public string Conteudo { get; set; }

        public int id_linguagem { get; set; }

        public int id_publicacao { get; set; }

        public string Imagem1 { get; set; }
        public string Imagem2 { get; set; }
        public string Imagem3 { get; set; }
        public string Imagem4 { get; set; }
        public string Imagem5 { get; set; }
        public string Imagem6 { get; set; }
        public string Imagem7 { get; set; }
        public string Imagem8 { get; set; }
        public string Imagem9 { get; set; }
        public string Imagem10 { get; set; }

        public string JsonImagens
        {
            get
            {
                List<String> saida = new List<string>();

                for (int i = 1; i < 10; i++)
                {
                    var img = Convert.ToString(Util.GetPropValue(this, "Imagem" + i));
                    saida.Add(img);
                }

                return JsonConvert.SerializeObject(saida.ToArray());


            }

        }



        public string Tipo { get; set; }
        public string URL { get; set; }


    }


}