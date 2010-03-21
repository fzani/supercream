using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Entity;

using SP.Core.DataInterfaces;
using SP.Core;

namespace SP.Data.LTS
{
    public abstract class AbstractLTSDao<T, IdT> : IDao<T, IdT> where T : class
    {

        #region IDao<T,IdT> Members

        protected LTSDataContext db = new LTSDataContext();

        public AbstractLTSDao()
        {
        }

        public AbstractLTSDao(LTSDataContext db)
        {
            this.db = db;
        }

        public object GetDataContext()
        {
            return db;
        }

        public void SetDataContext(object DataContext)
        {
            db = DataContext as LTSDataContext;
        }

        public virtual T GetById(IdT id)
        {

            return default(T);

        }

        public virtual List<T> GetAll()
        {
            Table<T> someTable = db.GetTable(typeof(T)) as Table<T>;
            return someTable.ToList<T>();
        }

        public virtual T Save(T entity)
        {
            ITable tab = db.GetTable(entity.GetType());
            tab.InsertOnSubmit(entity);
            this.CommitChanges();
            return entity;
        }

        public virtual T Update(T newEntity)
        {
            db.Log = Console.Out;

            ITable tab = db.GetTable(newEntity.GetType());           
            tab.Attach(newEntity, true);
               
            this.CommitChanges();
            return newEntity;
        }

        public virtual T Update(T newEntity, T originalEntity, bool attach)
        {
            db.Log = Console.Out;

            ITable tab = db.GetTable(newEntity.GetType());
            if (attach)
            {
                if (originalEntity == null)
                {
                    tab.Attach(newEntity, true);
                }
                else
                {
                    tab.Attach(newEntity, originalEntity);
                }
            }
            this.CommitChanges();
            return newEntity;
        }

        public virtual T Update(T newEntity, T originalEntity)
        {
            db.Log = Console.Out;

            ITable tab = db.GetTable(newEntity.GetType());
            if (originalEntity == null)
            {
                tab.Attach(newEntity, true);
            }
            else
            {
                tab.Attach(newEntity, originalEntity);
            }
            this.CommitChanges();
            return newEntity;
        }

        public virtual void Delete(T entity)
        {

            ITable tab = db.GetTable(entity.GetType());
            tab.Attach(entity);
            tab.DeleteOnSubmit(entity);
            this.CommitChanges();
        }

        public virtual void CommitChanges()
        {
            try
            {
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
                //Log Message to somewhere
                //e.Message;

                foreach (ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    occ.Resolve(RefreshMode.KeepChanges);
                }

            }

            db.SubmitChanges(ConflictMode.FailOnFirstConflict);
        }

        #endregion
    }
}
