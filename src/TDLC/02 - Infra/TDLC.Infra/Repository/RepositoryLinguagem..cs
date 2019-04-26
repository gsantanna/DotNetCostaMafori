
using System.Data.Entity;

namespace TDLC.Infra.Repository
{
    public class RepositoryLinguagem : Repository<Entities.Linguagem>
    {
        public RepositoryLinguagem() { }
        public RepositoryLinguagem(DbContext Context) : base(Context) { }


        







    }


}
