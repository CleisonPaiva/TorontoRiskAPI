using TorontoRiskAPI.Models;

namespace TorontoRiskAPI.Services.Interfaces
{
    public interface IHospitalService
    {
        Task<IEnumerable<Hospital>> GetAllAsync();
        Task<IEnumerable<Hospital>> GetAtRiskAsync();
    }
}
