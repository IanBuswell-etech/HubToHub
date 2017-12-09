using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Central.Data
{
    public interface IDataService
    {
        bool AddItem<T>(T obj);

        IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetList<T>();

        void DeleteFromDb<T>(Expression<Func<T, bool>> predicate);
    }
}
