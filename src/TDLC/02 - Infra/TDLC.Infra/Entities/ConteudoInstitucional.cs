

namespace TDLC.Infra.Entities
{

    public class ConteudoInstitucional
    {
        
        public int id_conteudoinstitucional { get; set; }

        public int id_institucional { get; set; }

        public int id_linguagem { get; set; }
        public virtual Linguagem Linguagem { get; set; }        
        public string Conteudo { get; set; }


        public virtual Institucional Institucional { get; set; }
                
    }
}
