using Microsoft.EntityFrameworkCore;
using TorontoRiskAPI.Data;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Services
{
    public class SchoolService(TorontoRiskDbContext context) : ISchoolService
    {
        public async Task<FeatureCollectionDto<SchoolPropertiesDto>> GetAllAsync()
        {
            var schools = await context.Schools.ToListAsync();
            var features = schools.Select(s => new FeatureDto<SchoolPropertiesDto>
            {
                Type = "Feature",
                Properties = new SchoolPropertiesDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    AddrStreet = s.AddrStreet,
                    Website = s.Website,
                    AtRisk = s.AtRisk
                },
                Geometry = s.Geometry
            });

            return new FeatureCollectionDto<SchoolPropertiesDto>
            {
                Type = "FeatureCollection",
                Features = features.ToList()
            };
        }

        public async Task<FeatureCollectionDto<SchoolPropertiesDto>> GetAtRiskAsync()
        {
            var atRiskSchools = await context.Schools
                .Where(s => s.AtRisk)
                .ToListAsync();

            var features = atRiskSchools.Select(s => new FeatureDto<SchoolPropertiesDto>
            {
                Type = "Feature",
                Properties = new SchoolPropertiesDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    AddrStreet = s.AddrStreet,
                    Website = s.Website,
                    AtRisk = s.AtRisk
                },
                Geometry = s.Geometry
            });

            return new FeatureCollectionDto<SchoolPropertiesDto>
            {
                Type = "FeatureCollection",
                Features = features.ToList()
            };
        }
    }
}
