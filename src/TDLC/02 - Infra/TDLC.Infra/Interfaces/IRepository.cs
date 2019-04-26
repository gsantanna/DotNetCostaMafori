
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TDLC.Infra
{
    public interface IRepository<T> : IDisposable where T : class, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T
                                         , object>>[] includeProperties);

        

        T Create();
        DbSet<E> Create<E>() where E : class, new();
        T Insert(T model);
        bool Edit(T model);
        bool Delete(T model);
        bool Delete(Expression<Func<T, bool>> where);
        bool Delete(params object[] Keys);
        T Find(params object[] Keys);
        T Find(Expression<Func<T, bool>> where);
        IQueryable<T> Query();
        IQueryable<T> Query(params Expression<Func<T, object>>[] includes);
        IQueryable<T> QueryFast();
        IQueryable<T> QueryFast(params Expression<Func<T, object>>[] includes);
        DbContext Context { get; }
        DbSet<T> Model { get; }
        int Save();
        Task<Int32> SaveAsync();
    }


}
