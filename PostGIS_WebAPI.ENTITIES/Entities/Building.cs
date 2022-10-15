using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostGIS_WebAPI.ENTITIES.Entities
{
    public class Building : BaseEntity
    {
        public string osm_id { get; set; }
        public string lastchange { get; set; }
        public int code { get; set; }
        public string fclass { get; set; }
        public char geomtype { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int height { get; set; }
        public int levels { get; set; }
        public int category { get; set; }
        public bool isActive { get; set; }
    }
}
