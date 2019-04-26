using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDLC.UI.Areas.Admin.Models.ViewModels
{
    public class InstituicaoContemplada
    {

        public string Nome { get; set; }        
        public string Logo { get; set; }
        public string Descricao { get; set; }
        public string link { get; set; }
        
        public int Ordem { get; set; }


        //propriedades padrão
        public string CriadoPor { get; set; }
        public string ModificadoPor { get; set; }
        
        public DateTime Criado { get; set; }
        public DateTime Modificado { get; set; }

             


    }
}