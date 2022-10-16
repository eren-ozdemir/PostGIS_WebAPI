using PostGIS_WebAPI.ENTITIES.Entities;
using PostGIS_WebAPI.REPOSITORIES.Abstract;
using PostGIS_WebAPI.REPOSITORIES.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PostGIS_WebAPI.REPOSITORIES.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CityContext _db;

        public GenericRepository(CityContext db)
        {
            _db = db;
        }

        public bool Activate(T item)
        {
            item.IsActive = true;
            return Save();
        }

        public bool ActivateAll()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var inactives = _db.Set<T>().Where(x => !x.IsActive).ToList();
                    foreach (T item in inactives)
                    {
                        item.IsActive = true;
                    }
                    Save();
                    ts.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Add(T item)
        {
            _db.Set<T>().Add(item);
            return Save();
        }

        public bool Add(List<T> item)
        {
            _db.Set<T>().AddRange(item);
            return Save();
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }

        public  T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T GetDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public bool Remove(T item)
        {
            item.IsActive = false;
            return Save();
        }

        public bool Remove(List<T> items)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (T item in items)
                        Remove(item);

                    ts.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public  bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(T item)
        {
            _db.Set<T>().Update(item);
            return Save();
        }
    }
}
