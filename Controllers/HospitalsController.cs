using Microsoft.AspNetCore.Mvc;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalsController(IHospitalService hospitalService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospital>>> GetAll()
        {
            return Ok(await hospitalService.GetAllAsync());
        }

        [HttpGet("at-risk")]
        public async Task<ActionResult<IEnumerable<Hospital>>> GetAtRisk()
        {
            return Ok(await hospitalService.GetAtRiskAsync());
        }
    }
}
