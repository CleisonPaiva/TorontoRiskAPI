using Microsoft.AspNetCore.Mvc;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolsController(ISchoolService schoolService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<FeatureCollectionDto<SchoolPropertiesDto>>> GetAll()
        {
            return Ok(await schoolService.GetAllAsync());
        }

        [HttpGet("at-risk")]
        public async Task<ActionResult<FeatureCollectionDto<SchoolPropertiesDto>>> GetAtRisk()
        {
            return Ok(await schoolService.GetAtRiskAsync());
        }
    }
}
