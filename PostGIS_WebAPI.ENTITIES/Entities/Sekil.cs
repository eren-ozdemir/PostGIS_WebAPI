using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PostGIS_WebAPI.ENTITIES.Entities
{
    public class Sekil
    {
        public string Type { get; set; }
        public double[][][] Coordinates { get; set; }
        public MultiPolygon MultiPolygon { get; set; }

        public void CreatePolygon()
        {
            Coordinate[] arr = new Coordinate[5];
            for (int i = 0; i < 5; i++)
            {
                arr[i] = new Coordinate() { X = Coordinates[0][i][0], Y = Coordinates[0][i][1] };
            }

            Polygon Cokgen = new Polygon(new LinearRing(arr));
            MultiPolygon = new MultiPolygon(new Polygon[] { Cokgen }, new GeometryFactory(new PrecisionModel(), 4326));
        }
    }
}
