using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLC.Infra.Entities
{
    public class Escritorio
    {
        public int id_escritorio { get; set; }

        public Localidade Localidade { get; set; }

        public int id_localidade { get; set; }

        public int Ordem { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string EnderecoL1 { get; set; }

        public string EnderecoL2 { get; set; }

        public string Mapa { get; set; }




    }
}

