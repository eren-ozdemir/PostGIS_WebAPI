using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostGIS_WebAPI.BUSINESS.Abstract;
using PostGIS_WebAPI.ENTITIES.Entities;
using System.Text.Json;

namespace PostGIS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawingController : ControllerBase
    {
        private readonly IGenericService<Building> _buildingService;

        public DrawingController(IGenericService<Building> buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetBuildings()
        {
            return Ok(_buildingService.GetAll());
        }

        [HttpPut]
        [Route("ActivateAll")]
        public IActionResult ActivateAll()
        {
            if (!_buildingService.ActivateAll())
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        [Route("RemoveIntersects")]
        public IActionResult RemoveIntersects([FromBody] FeatureCollection featureCollection)
        {
            if (featureCollection == null)
                return BadRequest();
            else if (featureCollection.Features.Count == 0)
                return BadRequest("No Feature Detected");


            List<Building> allIntersects = new List<Building>();

            foreach (Feature item in featureCollection.Features)
            {
                List<Building> intersects = _buildingService.GetByDefault(x => x.Geom.Intersects(item.Geometry.MultiPolygon));
                allIntersects.AddRange(intersects);
            }
            _buildingService.Remove(allIntersects);

            return Ok();
        }

        [HttpPost]
        [Route("GetIntersectingFeatures")]
        public IActionResult GetIntersectingFeatures([FromBody] FeatureCollection featureCollection)
        {
            if (featureCollection == null)
                return BadRequest();
            else if (featureCollection.Features.Count == 0)
                return BadRequest("No Feature Detected");

            List<Building> allIntersects = new List<Building>();

            foreach (Feature item in featureCollection.Features)
            {
                List<Building> intersects = _buildingService.GetByDefault(x => x.Geom.Intersects(item.Geometry.MultiPolygon));
                allIntersects.AddRange(intersects);

            }
            

            return Ok(_buildingService.ListToGeoJson(allIntersects));
        }
    }
}
