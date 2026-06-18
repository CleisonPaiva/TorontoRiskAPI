using Microsoft.EntityFrameworkCore;
using TorontoRiskAPI.Data;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Services
{
    public class FloodZoneService(TorontoRiskDbContext context) : IFloodZoneService
    {
        public async Task<IEnumerable<FloodZone>> GetAllAsync()
        {
            return await context.FloodZones.ToListAsync();
        }
    }
}
