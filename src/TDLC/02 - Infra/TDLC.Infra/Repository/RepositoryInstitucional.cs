
using System.Data.Entity;
using TDLC.Infra.Entities;

namespace TDLC.Infra.Repository
{

    #region Institucional 
    public class RepositoryInstitucional : Repository<Institucional>
    {
        public RepositoryInstitucional() { }
        public RepositoryInstitucional(DbContext Context) : base(Context) { }

        public bool DeleteExp(Institucional model)
        {
            //limpa os conteúdos 
            LimpaConteudo(model);
            this.Context.Entry<Institucional>(model).State = EntityState.Detached;

            RepositoryInstitucional _repo = new RepositoryInstitucional();
            _repo.Delete(model.id_institucional);
            return _repo.Save() > 0;
        }

        public void LimpaConteudo(Institucional model)
        {
            Repository<ConteudoInstitucional> _repo = new RepositoryConteudoInstitucional();

            for (int i = 0; i < model.Conteudos.Count; i++)
            {
                this.Context.Entry<ConteudoInstitucional>(model.Conteudos[i]).State = EntityState.Detached;
                _repo.Delete(model.Conteudos[i].id_conteudoinstitucional);
                _repo.Save();

            }
            this.Save();



        }

    }
    #endregion
        
    public class RepositoryConteudoInstitucional : Repository<ConteudoInstitucional>
    {
        public RepositoryConteudoInstitucional() { }
        public RepositoryConteudoInstitucional(DbContext Context) : base(Context) { }

    }
    



}
