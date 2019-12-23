using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Blog_Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(Expression<Func<T, bool>> filter = null, Func<IEnumerable<T>, IOrderedEnumerable<T>> orderBy = null);
        int Add(T entity);
        bool Delete(int id);

        bool Update(T entity);
        T FindById(int Id);
    }
}
