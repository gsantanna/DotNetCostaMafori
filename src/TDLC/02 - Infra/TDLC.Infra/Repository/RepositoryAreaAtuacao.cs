
using System.Collections.Generic;
using System.Data.Entity;
using TDLC.Infra.Entities;

namespace TDLC.Infra.Repository
{
    #region AreaAtuacao 
    public class RepositoryAreaAtuacao : Repository<AreaAtuacao>
    {
        public RepositoryAreaAtuacao() { }
        public RepositoryAreaAtuacao(DbContext Context) : base(Context) { }

        public bool DeleteExp(AreaAtuacao model)
        {
            //limpa os conteúdos 
            LimpaConteudo(model);
            this.Context.Entry<AreaAtuacao>(model).State = EntityState.Detached;

            RepositoryAreaAtuacao _repo = new RepositoryAreaAtuacao();
            _repo.Delete(model.id_areatuacao);
            return _repo.Save() > 0;
        }

        public void LimpaConteudo(AreaAtuacao model)
        {
            Repository<ConteudoAreaAtuacao> _repo = new RepositoryConteudoAreaAtuacao();

            for (int i = 0; i < model.Conteudos.Count; i++)
            {
                this.Context.Entry<ConteudoAreaAtuacao>(model.Conteudos[i]).State = EntityState.Detached;
                _repo.Delete(model.Conteudos[i].id_conteudoareatuacao);
                _repo.Save();

            }
            this.Save();



        }

      
    }

    

    #endregion



    public class RepositoryConteudoAreaAtuacao : Repository<ConteudoAreaAtuacao>
    {
        public RepositoryConteudoAreaAtuacao() { }
        public RepositoryConteudoAreaAtuacao(DbContext Context) : base(Context) { }

    }






}
