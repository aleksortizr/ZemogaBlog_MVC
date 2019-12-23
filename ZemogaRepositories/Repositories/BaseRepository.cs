using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Blog_Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected IDataContext _dbContext;

        protected LinqToDB.ITable<T> _dbSet;

        public ITable<T> DBSet { get; set; }

        public BaseRepository(IDataContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.GetTable<T>();
        }

        ITable<T> DbContext
        {
            get { return _dbSet; }

        }

        /// <summary>
        /// This methos is supossed to be called from the specific repositories, after handling filtering and ordering parameters
        /// It is recommended to handle exceptions in the calling method
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public IEnumerable<T> List(Expression<Func<T, bool>> filter = null, Func<IEnumerable<T>, IOrderedEnumerable<T>> orderBy = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                _ = orderBy(query);
            }

            return query as IEnumerable<T>;
        }

        public int Add(T entity)
        {
            return (int) _dbContext.InsertWithInt32Identity<T>(entity);
        }

        public bool Delete(T item)
        {
            _dbContext.Delete<T>(item);
            return true; ;
        }

        public T FindById(int id)
        {
            var pkName = typeof(T).GetProperties().Where(prop => prop.GetCustomAttributes(typeof(LinqToDB.Mapping.PrimaryKeyAttribute), false).Count() > 0).First();
            var expression = ExpressionConversion<T>(entity => entity.FindDynamic<T>(pkName.Name, id));
            return _dbSet.Where<T>(expression).FirstOrDefault();
        }

        private static Func<T, bool> ExpressionConversion<T>(Expression<Func<T, bool>> expression)
        {
            Expression<Func<T, bool>> g = obj => expression.Compile().Invoke(obj);
            return g.Compile();
        }

        public T FindById(Guid id)
        {
            T item = _dbContext.GetByPk<T>(id);
            return item;
        }

        public bool Update(T entity)
        {
            _dbContext.Update(entity);
            return true;
        }

        public bool Delete(int id)
        {
            T item = _dbContext.GetByPk<T>(id);
            return Delete(item);
        }
    }
}
