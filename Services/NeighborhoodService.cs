using Microsoft.EntityFrameworkCore;
using TorontoRiskAPI.Data;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Services
{
    public class NeighborhoodService(TorontoRiskDbContext context) : INeighborhoodService
    {
        public async Task<FeatureCollectionDto<NeighborhoodPropertiesDto>> GetAllAsync()
        {
            var neighborhoods = await context.Neighborhoods.ToListAsync();
            var features = neighborhoods.Select(n => new FeatureDto<NeighborhoodPropertiesDto>
            {
                Type = "Feature",
                Properties = new NeighborhoodPropertiesDto
                {
                    Id = n.Id,
                    Name = System.Text.RegularExpressions.Regex.Replace(n.Name ?? "", @"\s*\(\d+\)$", ""),
                    RiskCount = n.RiskCount
                },
                Geometry = n.Geometry
            });

            return new FeatureCollectionDto<NeighborhoodPropertiesDto>
            {
                Type = "FeatureCollection",
                Features = features.ToList()
            };
        }

        public async Task<FeatureCollectionDto<NeighborhoodPropertiesDto>> GetAtRiskAsync()
        {
            var atRiskNeighborhoods = await context.Neighborhoods
                .Where(n => n.RiskCount > 0)
                .OrderByDescending(n => n.RiskCount)
                .ToListAsync();

            var features = atRiskNeighborhoods.Select(n => new FeatureDto<NeighborhoodPropertiesDto>
            {
                Type = "Feature",
                Properties = new NeighborhoodPropertiesDto
                {
                    Id = n.Id,
                    Name = System.Text.RegularExpressions.Regex.Replace(n.Name ?? "", @"\s*\(\d+\)$", ""),
                    RiskCount = n.RiskCount
                },
                Geometry = n.Geometry
            });

            return new FeatureCollectionDto<NeighborhoodPropertiesDto>
            {
                Type = "FeatureCollection",
                Features = features.ToList()
            };
        }
    }
}
