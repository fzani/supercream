/**************************************************************
* Project: Domain Code for SP.
* Filename: IDAO.cs
* Namespace: SP.Core.Domain
* Class: IDAO
*
* Description: Data Interface
*
* Version History
* Version    Date        Initials    Description
* ------------------------------------------------------------
* 1.0        17/12/2008JC         Initial version.
**************************************************************/

using System.Collections.Generic;

namespace SP.Core.DataInterfaces
{
    /// <summary>
    /// This interface was adapted from Billy Mccafferty's NHibernate Framework
    /// <see cref="http://devlicio.us/blogs/billy_mccafferty"/>
    /// C:\Documents and Settings\Administrator\Desktop\book_code\BoP\BoP.Core\DataInterfaces\IDao.cs
    /// The purpose of this interface is to provide a
    /// general purpose contract for CRUD operations
    /// executed in the ORM layer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="IdT"></typeparam>
    public interface IDao<T, IdT>
    {
        T GetById(IdT id);
        List<T> GetAll();
        T Save(T entity);
        T Update(T entity, T originalEntity);
        T Update(T entity, T originalEntity, bool attach);
        void Delete(T entity);
        object GetDataContext();
        void SetDataContext(object DataContext);
        void CommitChanges();
    }
}
