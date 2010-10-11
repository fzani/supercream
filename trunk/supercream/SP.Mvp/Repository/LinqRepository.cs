using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Linq;
using System.Threading;

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
            try
            {
                var rdr = _beginFindAllCmd.EndExecuteReader(result);
                var entities = (from w in _dataContext.Translate<TEntity>(rdr)
                                select w).ToList();
                rdr.Close();
                return entities;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public TEntity Save(TEntity newEntity)
        {
            if (newEntity.ID <= 0)
            {
                ITable table = _dataContext.GetTable(newEntity.GetType());
                table.InsertOnSubmit(newEntity);
            }
            else
            {
                throw new ApplicationException("Cannot save entity that already exists");
            }
            return newEntity;
        }

        public TEntity Save(TEntity newEntity, TEntity originalEntity)
        {
            ITable table = _dataContext.GetTable(newEntity.GetType());
            table.Attach(newEntity, originalEntity);
            
            return newEntity;
        }

        public void Delete(TEntity entity)
        {
            ITable tab = _dataContext.GetTable(entity.GetType());
            tab.Attach(entity);
            tab.DeleteOnSubmit(entity);
        }

        #endregion
    }
}
