using LinqToDB;
using LinqToDB.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Blog_Repositories
{
    public static class DataContextHelpers
    {
        public static T GetByPk<T>(this IDataContext context, object pkValue) where T : class
        {
            using (var db = new DataConnection())
            {
                var pkName = typeof(T).GetProperties().Where(prop => prop.GetCustomAttributes(typeof(LinqToDB.Mapping.PrimaryKeyAttribute), false).Count() > 0).First();
                var expression = ExpressionConversion<T>(entity => entity.FindDynamic<T>(pkName.Name, pkValue));
                return db.GetTable<T>().Where<T>(expression).FirstOrDefault();
            }
        }

        public static bool FindDynamic<T>(this T entity, string pkName, object pkValue) where T : class
        {
            var result = false;

            var propT = entity.GetType().GetProperty(pkName);

            if (propT != null)
            {
                var value = propT.GetValue(entity, null);
                result = value.Equals(pkValue);
            }

            return result;
        }

        private static Func<T, bool> ExpressionConversion<T>(Expression<Func<T, bool>> expression)
        {
            Expression<Func<T, bool>> g = obj => expression.Compile().Invoke(obj);
            return g.Compile();
        }
    }
}
