using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Portfolio.Domain.Interfaces
{
    public interface IDataContext
    {
        T Single<T>(Expression<Func<T, bool>> expression) where T : class, new();
        IQueryable<T> All<T>() where T : class, new();
        void Save<T>(T item) where T : class, new();
        void Save<T>(List<T> items) where T : class, new();
        void Delete<T>(Expression<Func<T, bool>> expression) where T : class, new();
    }
}
