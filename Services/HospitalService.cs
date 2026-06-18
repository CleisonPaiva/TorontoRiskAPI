using Microsoft.EntityFrameworkCore;
using TorontoRiskAPI.Data;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Services
{
    public class HospitalService(TorontoRiskDbContext context) : IHospitalService
    {
        public async Task<IEnumerable<Hospital>> GetAllAsync()
        {
            return await context.Hospitals.ToListAsync();
        }

        public async Task<IEnumerable<Hospital>> GetAtRiskAsync()
        {
            return await context.Hospitals
                .Where(h => h.AtRisk)
                .ToListAsync();
        }
    }
}
