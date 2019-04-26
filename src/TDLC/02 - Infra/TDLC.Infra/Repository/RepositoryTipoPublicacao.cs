
using System.Data.Entity;

namespace TDLC.Infra.Repository
{
    public class RepositoryTipoPublicacao : Repository<Entities.TipoPublicacao>
    {
        public RepositoryTipoPublicacao() { }
        public RepositoryTipoPublicacao(DbContext Context) : base(Context) { }


        







    }


}
