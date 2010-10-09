using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SP.Core.Domain;

namespace SP.Mvp
{
    public interface IRepository<TEntity>
    {
        TEntity Find(int id);
        IAsyncResult BeginFind(int id, AsyncCallback callback, Object asyncState);
        TEntity EndFind(IAsyncResult result);
        IEnumerable<TEntity> FindAll();
        IAsyncResult BeginFindAll(AsyncCallback callback, Object asyncState);
        IEnumerable<TEntity> EndFindAll(IAsyncResult result);
        TEntity Save(TEntity entity, TEntity originalEntity);
    }
}
