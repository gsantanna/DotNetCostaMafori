using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDLC.UI.Areas.Admin.Models.ViewModels;

namespace TDLC.UI.Models
{
   public class EquipeSiteViewmodel
    {
        public EquipeViewmodel SocioFundador { get; set; }        

        public List<EquipeViewmodel> Socios { get; set; }

        public List<EquipeViewmodel> Advogados { get; set; }

        public List<EquipeViewmodel> Equipes { get; set; }

        public EquipeSiteViewmodel()
        {
            SocioFundador = new EquipeViewmodel();
            Socios = new List<EquipeViewmodel>();
            Advogados = new List<EquipeViewmodel>();
            Equipes = new List<EquipeViewmodel>();
        }

    }
}
