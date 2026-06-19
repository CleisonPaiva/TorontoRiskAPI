using Microsoft.EntityFrameworkCore;
using TorontoRiskAPI.Data;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Services
{
    public class SubwayService(TorontoRiskDbContext context) : ISubwayService
    {
        public async Task<FeatureCollectionDto<SubwayPropertiesDto>> GetAllAsync()
        {
            var subways = await context.Subways.ToListAsync();
            var features = subways.Select(s => new FeatureDto<SubwayPropertiesDto>
            {
                Type = "Feature",
                Properties = new SubwayPropertiesDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    AtRisk = s.AtRisk
                },
                Geometry = s.Geometry
            });

            return new FeatureCollectionDto<SubwayPropertiesDto>
            {
                Type = "FeatureCollection",
                Features = features.ToList()
            };
        }

        public async Task<FeatureCollectionDto<SubwayPropertiesDto>> GetAtRiskAsync()
        {
            var atRiskSubways = await context.Subways
                .Where(s => s.AtRisk)
                .ToListAsync();

            var features = atRiskSubways.Select(s => new FeatureDto<SubwayPropertiesDto>
            {
                Type = "Feature",
                Properties = new SubwayPropertiesDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    AtRisk = s.AtRisk
                },
                Geometry = s.Geometry
            });

            return new FeatureCollectionDto<SubwayPropertiesDto>
            {
                Type = "FeatureCollection",
                Features = features.ToList()
            };
        }
    }
}
