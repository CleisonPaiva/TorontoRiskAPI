using Microsoft.EntityFrameworkCore;
using TorontoRiskAPI.Data;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Services
{
    public class NeighborhoodService(TorontoRiskDbContext context) : INeighborhoodService
    {
        public async Task<IEnumerable<Neighborhood>> GetAllAsync()
        {
            return await context.Neighborhoods.ToListAsync();
        }
    }
}
