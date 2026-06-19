using TorontoRiskAPI.Models;

namespace TorontoRiskAPI.Services.Interfaces
{
    public interface IHospitalService
    {
        Task<FeatureCollectionDto<HospitalPropertiesDto>> GetAllAsync();
        Task<FeatureCollectionDto<HospitalPropertiesDto>> GetAtRiskAsync();
    }
}
