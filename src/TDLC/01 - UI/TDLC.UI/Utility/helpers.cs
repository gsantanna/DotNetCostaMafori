
using System.Linq;
using TDLC.Infra.Entities;
using TDLC.Infra.Repository;



public static class ConteudoInstitucionalHelper
{
    public static string GetImage (string nome)
    {
        string strSaida = "";
        nome = nome.Trim();

        using (Repository<Institucional> _repo = new RepositoryInstitucional())
        {
            var entidade = _repo.QueryFast().FirstOrDefault(f => f.Nome.ToUpper() == nome.ToUpper());
            if (entidade != null) strSaida = entidade.Arquivo;
        }

        return strSaida;
    }

    public static string GetText(string cultura, string nome)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(cultura)) cultura = "pt_BR";

            nome = nome.Trim();

            string strResposta = "Item não encontrado! " + nome;

            using (Repository<ConteudoInstitucional> _repo = new RepositoryConteudoInstitucional())
            {
                var entidade = _repo.Query().Where(f => f.Institucional.Nome.ToUpper().Trim() == nome.ToUpper().Trim());

                if (entidade == null) //item não encontrado 
                {
                    strResposta = "Item não encontrado " + nome;
                    return strResposta;
                }

                var cont = entidade.FirstOrDefault(f => f.Linguagem.Cultura == cultura);

                //.FirstOrDefault(f => f.Linguagem.Cultura == cultura && f.Institucional.Nome.ToUpper().Trim() ==nome.ToUpper().Trim() );
                if (cont != null && cont.Conteudo.Length > 0)
                {
                    strResposta = cont.Conteudo;
                }
                else
                {
                    strResposta = entidade.OrderBy(f => f.id_linguagem).First().Conteudo;
                }
            }

            return strResposta;

        } catch
        {
            return $"O item: {nome} não foi encontrado no sistema";

        }



    }


}


