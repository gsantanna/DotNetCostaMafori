using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLC.Infra.Entities
{
    public class Localidade
    {
        public int id_localidade { get; set; }

        public string Nome { get; set;}

        public string Abreviacao { get; set; }

        public int Ordem { get; set; }


        //backw nav
        public  virtual  List<Escritorio> Escritorios { get; set; }
    }
}
