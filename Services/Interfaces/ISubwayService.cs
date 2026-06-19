using TorontoRiskAPI.Models;

namespace TorontoRiskAPI.Services.Interfaces
{
    public interface ISubwayService
    {
        Task<FeatureCollectionDto<SubwayPropertiesDto>> GetAllAsync();
        Task<FeatureCollectionDto<SubwayPropertiesDto>> GetAtRiskAsync();
    }
}
