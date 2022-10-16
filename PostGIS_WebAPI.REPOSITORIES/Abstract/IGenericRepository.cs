using PostGIS_WebAPI.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PostGIS_WebAPI.REPOSITORIES.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        bool Add(T item);
        bool Add(List<T> item);
        bool Update(T item);
        bool Remove(T item);
        bool Remove(List<T> item);
        List<T> GetAll();
        T GetById(int id);
        T GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetByDefault(Expression<Func<T, bool>> exp);
        bool Activate(T item);
        bool ActivateAll();
        bool Save();
    }
}
