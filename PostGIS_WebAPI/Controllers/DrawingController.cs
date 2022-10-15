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
        public IActionResult GetBuildings()
        {
            return Ok(_buildingService.GetAll());
        }

        [HttpPost]
        [Route("RemoveIntersects")]
        public IActionResult RemoveIntersects(FeatureCollection featureCollection)
        {
            if (featureCollection == null)
                return BadRequest();

            foreach (Feature item in featureCollection.Features)
            {
                var buildings = _buildingService.GetByDefault(x => x.Geom.Intersects(item.Geom));
            }

            return Ok();
        }
    }
}
