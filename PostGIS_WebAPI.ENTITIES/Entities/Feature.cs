using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostGIS_WebAPI.ENTITIES.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Geometry Geom { get; set; }
        public string Properties { get; set; }
    }
}
