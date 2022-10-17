using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PostGIS_WebAPI.ENTITIES.Entities
{
    public class MyGeometry
    {
        public string Type { get; set; }
        public MultiPolygon MultiPolygon { get; set; }

        private double[][][] _coordinates;

        public double[][][] Coordinates
        {
            get { return _coordinates; }
            set 
            { 
                _coordinates = value; 
                CreatePolygon();
            }
        }

        private void CreatePolygon()
        {
            Coordinate[] arr = new Coordinate[_coordinates[0].Length];
            for (int i = 0; i < _coordinates[0].Length; i++)
            {
                arr[i] = new Coordinate() { X = _coordinates[0][i][0], Y = _coordinates[0][i][1] };
            }

            Polygon Cokgen = new Polygon(new LinearRing(arr));
            MultiPolygon = new MultiPolygon(new Polygon[] { Cokgen }, new GeometryFactory(new PrecisionModel(), 4326));
        }
    }
}
