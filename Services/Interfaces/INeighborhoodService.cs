using TorontoRiskAPI.Models;

namespace TorontoRiskAPI.Services.Interfaces
{
    public interface INeighborhoodService
    {
        Task<IEnumerable<Neighborhood>> GetAllAsync();
        Task<IEnumerable<Neighborhood>> GetAtRiskAsync();
    }
}
