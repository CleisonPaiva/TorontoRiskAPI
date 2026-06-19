using Microsoft.AspNetCore.Mvc;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubwaysController(ISubwayService subwayService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<FeatureCollectionDto<SubwayPropertiesDto>>> GetAll()
        {
            return Ok(await subwayService.GetAllAsync());
        }

        [HttpGet("at-risk")]
        public async Task<ActionResult<FeatureCollectionDto<SubwayPropertiesDto>>> GetAtRisk()
        {
            return Ok(await subwayService.GetAtRiskAsync());
        }
    }
}
