using Microsoft.EntityFrameworkCore;
using TorontoRiskAPI.Data;
using TorontoRiskAPI.Models;
using TorontoRiskAPI.Services.Interfaces;

namespace TorontoRiskAPI.Services
{
    public class HospitalService(TorontoRiskDbContext context) : IHospitalService
    {
        public async Task<FeatureCollectionDto<HospitalPropertiesDto>> GetAllAsync()
        {
            var hospitals = await context.Hospitals.ToListAsync();
            var features = hospitals.Select(h => new FeatureDto<HospitalPropertiesDto>
            {
                Type = "Feature",
                Properties = new HospitalPropertiesDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    AddrStreet = h.AddrStreet,
                    Website = h.Website,
                    AtRisk = h.AtRisk
                },
                Geometry = h.Geometry
            });
            return new FeatureCollectionDto<HospitalPropertiesDto>
            {
                Type = "FeatureCollection",
                Features = features.ToList()
            };
        }

        public async Task<FeatureCollectionDto<HospitalPropertiesDto>> GetAtRiskAsync()
        {
            var atRiskHospitals = await context.Hospitals
                .Where(h => h.AtRisk)
                .ToListAsync();

            var features = atRiskHospitals.Select(h => new FeatureDto<HospitalPropertiesDto>
            {
                Type = "Feature",
                Properties = new HospitalPropertiesDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    AddrStreet = h.AddrStreet,
                    Website = h.Website,
                    AtRisk = h.AtRisk
                },
                Geometry = h.Geometry
            });

            return new FeatureCollectionDto<HospitalPropertiesDto>
            {
                Type = "FeatureCollection",
                Features = features.ToList()
            };
        }
    }
}
