
namespace TDLC.Infra.Entities
{
    public class ConteudoAreaAtuacao
    {
        public int id_conteudoareatuacao { get; set; }
        public AreaAtuacao AreaAtuacao { get; set; }
        public int id_areaatuacao { get; set; }
        public string Nome { get; set; }
        public string Chamada { get; set; }
        public string Conteudo { get; set; }
        public int id_linguagem { get; set; }
        public virtual Linguagem Linguagem { get; set; }

    }
}
