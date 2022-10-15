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
        public string Osm_Id { get; set; }
        public string LastChange { get; set; }
        public int Code { get; set; }
        public string FClass { get; set; }
        public char GeomType { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Height { get; set; }
        public int Levels { get; set; }
        public int Category { get; set; }
    }
}
