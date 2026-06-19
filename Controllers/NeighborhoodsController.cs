using Microsoft.AspNetCore.Mvc;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Controllers
{
    [ApiController]
    [Route("api/neighborhoods")]
    public class NeighborhoodsController(INeighborhoodService neighborhoodService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<FeatureCollectionDto<NeighborhoodPropertiesDto>>> GetAll()
        {
            return Ok(await neighborhoodService.GetAllAsync());
        }

        [HttpGet("at-risk")]
        public async Task<ActionResult<FeatureCollectionDto<NeighborhoodPropertiesDto>>> GetAtRisk()
        {
            return Ok(await neighborhoodService.GetAtRiskAsync());
        }
    }
}
