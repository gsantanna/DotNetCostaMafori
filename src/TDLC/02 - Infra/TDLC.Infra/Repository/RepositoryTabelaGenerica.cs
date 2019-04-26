
using System.Data.Entity;
using System.Collections.Generic;
using TDLC.Infra.Entities;

namespace TDLC.Infra.Repository
{
    #region TabelaGenerica 
    public class RepositoryTabelaGenerica : Repository<TabelaGenerica>
    {


        public RepositoryTabelaGenerica() { }
        public RepositoryTabelaGenerica(DbContext Context) : base(Context) { }


        public ICollection<ItemTabelaGenerica> GetItemsByTabela(string NomeTabela)
        {
            return this.Find(x => x.Nome == NomeTabela).Items;
        }


    }
    #endregion

    public class RepositoryItemTabelaGenerica : Repository<ItemTabelaGenerica>
    {
        public RepositoryItemTabelaGenerica() { }
        public RepositoryItemTabelaGenerica(DbContext Context) : base(Context) { }

    }







}
