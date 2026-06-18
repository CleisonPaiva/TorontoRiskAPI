using TorontoRiskAPI.Models;

namespace TorontoRiskAPI.Services.Interfaces
{
    public interface ISubwayService
    {
        Task<IEnumerable<Subway>> GetAllAsync();
        Task<IEnumerable<Subway>> GetAtRiskAsync();
    }
}
