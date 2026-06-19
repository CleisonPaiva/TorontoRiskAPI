using Microsoft.EntityFrameworkCore;
using TorontoRiskAPI.Data;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Services
{
    public class FloodZoneService(TorontoRiskDbContext context) : IFloodZoneService
    {
        public async Task<FeatureCollectionDto<FloodZonePropertiesDto>> GetAllAsync()
        {
            var floodZones = await context.FloodZones.ToListAsync();
            var features = floodZones.Select(fz => new FeatureDto<FloodZonePropertiesDto>
            {
                Type = "Feature",
                Properties = new FloodZonePropertiesDto
                {
                    Id = fz.Id
                },
                Geometry = fz.Geometry
            });

            return new FeatureCollectionDto<FloodZonePropertiesDto>
            {
                Type = "FeatureCollection",
                Features = features.ToList()
            };
        }
    }
}
