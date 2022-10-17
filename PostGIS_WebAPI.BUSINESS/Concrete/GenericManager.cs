using PostGIS_WebAPI.BUSINESS.Abstract;
using PostGIS_WebAPI.ENTITIES.Entities;
using PostGIS_WebAPI.REPOSITORIES.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PostGIS_WebAPI.BUSINESS.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repo;

        public GenericManager(IGenericRepository<T> repo)
        {
            _repo = repo;
        }
        public bool Activate(T item)
        {
            if(item == null)
                return false;

            return Activate(item);
        }

        public bool ActivateAll()
        {
            return _repo.ActivateAll();
        }

        public bool Add(T item)
        {
            if (item == null)
                return false;

           return _repo.Add(item);
        }

        public bool Add(List<T> item)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return _repo.GetAll();
        }

        public List<T> GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _repo.GetByDefault(exp);
        }

        public T GetById(int id)
        {
            return _repo.GetById(id);
        }

        public T GetDefault(Expression<Func<T, bool>> exp)
        {
            return _repo.GetDefault(exp);
        }

        public string ListToGeoJson(List<T> items)
        {
            var features = items.Where(x=>x.IsActive).Select(x => new { type = "Feature", geometry = x.Geom, id = x.Id });
            var options = new JsonSerializerOptions();

            options.Converters.Add(new NetTopologySuite.IO.Converters.GeoJsonConverterFactory());

            var serialized = JsonSerializer.Serialize(features, options);
            return serialized.ToString();
        }

        public bool Remove(T item)
        {
            if (item == null)
                return false;
            return _repo.Remove(item);
        }

        public bool Remove(List<T> items)
        {
            return _repo.Remove(items);
        }

        public bool Update(T item)
        {
            if (item == null)
                return false;

            return _repo.Update(item);
        }
    }
}
