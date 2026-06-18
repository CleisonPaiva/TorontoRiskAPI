using Microsoft.EntityFrameworkCore;
using TorontoRiskAPI.Data;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Services
{
    public class SubwayService(TorontoRiskDbContext context) : ISubwayService
    {
        public async Task<IEnumerable<Subway>> GetAllAsync()
        {
            return await context.Subways.ToListAsync();
        }

        public async Task<IEnumerable<Subway>> GetAtRiskAsync()
        {
            return await context.Subways
                .Where(s => s.AtRisk)
                .ToListAsync();
        }
    }
}
