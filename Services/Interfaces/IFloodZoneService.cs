using TorontoRiskAPI.Models;

namespace TorontoRiskAPI.Services.Interfaces
{
    public interface IFloodZoneService
    {
        Task<IEnumerable<FloodZone>> GetAllAsync();
    }
}
