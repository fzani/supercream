using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Linq;

namespace SP.Mvp.Repository
{
    public class LinqRepository<TEntity> : IRepository<TEntity>
            where TEntity : BaseEntity
    {
        private BundledOffersDataContext _dataContext;

        public LinqRepository(BundledOffersDataContext dataContext)
        {
            _dataContext = dataContext ?? new BundledOffersDataContext();
        }

        #region IRepository<TEntity> Members

        public TEntity Find(int id)
        {
            var table = _dataContext.GetTable(typeof(TEntity)) as Table<TEntity>;
            return table.ToList<TEntity>().Where(q => q.ID == id).SingleOrDefault();
        }

        private SqlCommand _beginFindCmd = null;
        public IAsyncResult BeginFind(int id, AsyncCallback callback, object asyncState)
        {
            var table = _dataContext.GetTable(typeof(TEntity)) as Table<TEntity>;
            var query = table.Where(q => q.ID == id).AsQueryable();

            _beginFindCmd = _dataContext.GetCommand(query) as SqlCommand;
            _dataContext.Connection.Open();
            return _beginFindCmd.BeginExecuteReader(callback, asyncState, System.Data.CommandBehavior.CloseConnection);
        }

        public TEntity EndFind(IAsyncResult result)
        {
            var rdr = _beginFindCmd.EndExecuteReader(result);
            var widget = (from w in _dataContext.Translate<TEntity>(rdr)
                          select w).SingleOrDefault();
            rdr.Close();
            return widget;
        }

        public IEnumerable<TEntity> FindAll()
        {
            var table = _dataContext.GetTable(typeof(TEntity)) as Table<TEntity>;
            return table.ToList<TEntity>();
        }

        private SqlCommand _beginFindAllCmd = null;
        public IAsyncResult BeginFindAll(AsyncCallback callback, object asyncState)
        {
            var table = _dataContext.GetTable(typeof(TEntity)) as Table<TEntity>;
            var query = table.AsQueryable();
            _beginFindAllCmd = _dataContext.GetCommand(query) as SqlCommand;
            _dataContext.Connection.Open();
            return _beginFindAllCmd.BeginExecuteReader(callback, asyncState, System.Data.CommandBehavior.CloseConnection);
        }

        public IEnumerable<TEntity> EndFindAll(IAsyncResult result)
        {
            var rdr = _beginFindAllCmd.EndExecuteReader(result);
            var entities = (from w in _dataContext.Translate<TEntity>(rdr)
                            select w).ToList();
            rdr.Close();
            return entities;
        }

        public TEntity Save(TEntity newEntity)
        {
            return Save(newEntity, null);           
        }

        public TEntity Save(TEntity newEntity, TEntity originalEntity)
        {
            if (newEntity.ID > 0)
            {
                // Update
                ITable table = _dataContext.GetTable(newEntity.GetType());
                table.Attach(newEntity, originalEntity);
            }
            else
            {
                ITable table = _dataContext.GetTable(newEntity.GetType());
                table.InsertOnSubmit(newEntity);
            }
            return newEntity;
        }

        #endregion
    }
}
