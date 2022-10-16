using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostGIS_WebAPI.ENTITIES.Entities
{
    public class Feature : BaseEntity
    {
        public string Type { get; set; }
        public string Properties { get; set; }
        public Sekil Geometry { get; set; }

    }
}
