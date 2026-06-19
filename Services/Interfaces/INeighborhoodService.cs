using TorontoRiskAPI.Models;

namespace TorontoRiskAPI.Services.Interfaces
{
    public interface INeighborhoodService
    {
        Task<FeatureCollectionDto<NeighborhoodPropertiesDto>> GetAllAsync();
        Task<FeatureCollectionDto<NeighborhoodPropertiesDto>> GetAtRiskAsync();
    }
}
