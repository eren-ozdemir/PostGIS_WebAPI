using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostGIS_WebAPI.ENTITIES.Entities
{
    public class FeatureCollection
    {
        public int Id { get; set; }
        public List<Feature> Features { get; set; }
    }
}
