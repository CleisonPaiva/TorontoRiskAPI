using Microsoft.EntityFrameworkCore;
using TorontoRiskAPI.Data;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Services
{
    public class SchoolService(TorontoRiskDbContext context) : ISchoolService
    {
        public async Task<IEnumerable<School>> GetAllAsync()
        {
            return await context.Schools.ToListAsync();
        }

        public async Task<IEnumerable<School>> GetAtRiskAsync()
        {
            return await context.Schools
                .Where(s => s.AtRisk)
                .ToListAsync();
        }
    }
}
