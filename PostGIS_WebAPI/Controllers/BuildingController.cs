using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostGIS_WebAPI.BUSINESS.Abstract;
using PostGIS_WebAPI.ENTITIES.Entities;

namespace PostGIS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IGenericService<Building> _buildingService;

        public BuildingController(IGenericService<Building> buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllBuildings()
        {
            return Ok(_buildingService.GetAll());
        }
    }
}
