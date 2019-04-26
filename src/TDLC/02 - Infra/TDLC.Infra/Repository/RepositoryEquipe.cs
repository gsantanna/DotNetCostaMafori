
using System.Data.Entity;
using TDLC.Infra.Entities;

namespace TDLC.Infra.Repository
{
    #region Equipe 
    public class RepositoryEquipe : Repository<Equipe>
    {
        public RepositoryEquipe() { }
        public RepositoryEquipe(DbContext Context) : base(Context) { }

        public  bool DeleteExp(Equipe model)
        {
            //limpa os conteúdos 
            LimpaConteudo(model);
            this.Context.Entry<Equipe>(model).State = EntityState.Detached;

            RepositoryEquipe _repo = new RepositoryEquipe();
            _repo.Delete(model.id_equipe);
            return _repo.Save() > 0;
        }

        public void LimpaConteudo(Equipe model)
        {
            Repository<ConteudoEquipe> _repo = new RepositoryConteudoEquipe();

            for (int i = 0; i < model.Conteudos.Count; i++)
            {
                this.Context.Entry<ConteudoEquipe>(model.Conteudos[i]).State = EntityState.Detached;
                _repo.Delete(model.Conteudos[i].id_conteudoequipe);
                _repo.Save();

            }
            this.Save();
            


        }

    }
    #endregion



    public class RepositoryConteudoEquipe : Repository<ConteudoEquipe>
    {
        public RepositoryConteudoEquipe() { }
        public RepositoryConteudoEquipe(DbContext Context) : base(Context) { }

    }






    }
