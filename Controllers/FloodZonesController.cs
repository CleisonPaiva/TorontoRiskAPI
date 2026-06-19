using Microsoft.AspNetCore.Mvc;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Controllers
{
    [ApiController]
    [Route("api/flood-zones")]
    public class FloodZonesController(IFloodZoneService floodZoneService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<FeatureCollectionDto<FloodZonePropertiesDto>>> GetAll()
        {
            return Ok(await floodZoneService.GetAllAsync());
        }
    }
}
