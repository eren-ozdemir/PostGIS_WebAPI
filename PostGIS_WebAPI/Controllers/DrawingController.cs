using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostGIS_WebAPI.BUSINESS.Abstract;
using PostGIS_WebAPI.ENTITIES.Entities;

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

            featureCollection.Features[0].Geometry.CreatePolygon();
            var chk = featureCollection.Features[0].Geometry;

            List<Building> allIntersects = new List<Building>();

            foreach (Feature item in featureCollection.Features)
            {
                List<Building> intersects = _buildingService.GetByDefault(x => x.Geom.Intersects(chk.MultiPolygon));
                allIntersects.AddRange(intersects);
            }
                _buildingService.Remove(allIntersects);

            return Ok();
        }
    }
}
