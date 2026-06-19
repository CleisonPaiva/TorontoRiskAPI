using TorontoRiskAPI.Models;

namespace TorontoRiskAPI.Services.Interfaces
{
    public interface ISchoolService
    {
        Task<FeatureCollectionDto<SchoolPropertiesDto>> GetAllAsync();
        Task<FeatureCollectionDto<SchoolPropertiesDto>> GetAtRiskAsync();
    }
}
