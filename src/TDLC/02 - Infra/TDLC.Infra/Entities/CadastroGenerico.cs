using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLC.Infra.Entities
{
    public class TabelaGenerica
    {

        public int id_tabelagenerica { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<ItemTabelaGenerica> Items { get; set; }

        public TabelaGenerica()
        {
            Items = new List<ItemTabelaGenerica>();
        }
    }


    public class ItemTabelaGenerica
    {
        public int id_itemtabelagenerica { get; set; }

        public int id_tabelagenerica { get; set; }
        public virtual TabelaGenerica TabelaGenerica { get; set; }

        public string valor1 { get; set; }
        public string valor2 { get; set; }
        public string valor3 { get; set; }
        public string valor4 { get; set; }
        public string valor5 { get; set; }
        public string valor6 { get; set; }
        public string valor7 { get; set; }
        public string valor8 { get; set; }
        public string valor9 { get; set; }
        public string valor10 { get; set; }

        public int? Numero1 { get; set; }
        public int? Numero2 { get; set; }
        public int? Numero3 { get; set; }
        public int? Numero4 { get; set; }
        public int? Numero5 { get; set; }


        public DateTime? Data1 { get; set; }
        public DateTime? Data2 { get; set; }
        public DateTime? Data3 { get; set; }
        public DateTime? Data4 { get; set; }
        public DateTime? Data5 { get; set; }

        public string TextoLongo1 { get; set; }
        public string TextoLongo2 { get; set; }
        public string TextoLongo3 { get; set; }

        public string Arquivo1 { get; set; }
        public string Arquivo2 { get; set; }



        public string CriadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime Criado { get; set; }
        public DateTime Modificado { get; set; }



    }




}

