using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDLC.UI.Areas.Admin.Models.ViewModels;

namespace TDLC.UI.Models
{
    public class HomeViewmodel
    {

        public List<ConteudoPublicacaoViewmodel> Destaques_topo { get; set; }

        public List<ConteudoPublicacaoViewmodel> Destaques_home { get; set; }


    }
}