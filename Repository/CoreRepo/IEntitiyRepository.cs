using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository.CoreRepo
{
    public interface IEntitiyRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //required for usşng linq function and expressions.
        T Get(Expression<Func<T, bool>> filter);   //get one data.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
