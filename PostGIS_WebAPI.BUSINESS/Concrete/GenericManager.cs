using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
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
            if (item == null)
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

        public List<T> GetIntersectingItems(FeatureCollection collection)
        {
            List<T> result = new List<T>();

            foreach (var item in collection)
            {
                List<T> intersects = GetByDefault(x => x.IsActive && x.Geometry.Intersects(item.Geometry));
                result.AddRange(intersects);
            }

            return result;
        }

        public T GetItemFromCoordinates(double[] coordinates)
        {
            GeometryFactory fact = new GeometryFactory(new PrecisionModel(), 4326);
            Point point = fact.CreatePoint(new Coordinate(coordinates[0], coordinates[1]));
            T result = GetDefault(x => x.IsActive && x.Geometry.Intersects(point));
            return result;
        }

        public List<T> GetBySQLQuery(string sql)
        {
            return _repo.GetBySQLQuery(sql);
        }
    }
}
