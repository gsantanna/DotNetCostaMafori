using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDLC.UI.Areas.Admin.Models.ViewModels;

namespace TDLC.UI.Models
{
    public class PublicacoesSiteViewmodel
    {
        public List<PublicacaoViewmodel> Publicacoes { get; set; }
        
        public List<PublicacaoViewmodel> Destaques { get; set; }
        public List<PublicacaoViewmodel> DestaquesMedio { get; set; }

        


        public PublicacoesSiteViewmodel()
        {
            Publicacoes = new List<PublicacaoViewmodel>();
            Destaques = new List<PublicacaoViewmodel>();
            DestaquesMedio = new List<PublicacaoViewmodel>();

        }


    }
}