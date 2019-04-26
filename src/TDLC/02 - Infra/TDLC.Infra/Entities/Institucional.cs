using System.Collections.Generic;
namespace TDLC.Infra.Entities
{

    public class Institucional
    {
        public int id_institucional { get; set; }
        public string Area { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }        
        public string Arquivo { get; set; } 
        
        
               
        public virtual List<ConteudoInstitucional> Conteudos { get; set; }
        


    }
}
