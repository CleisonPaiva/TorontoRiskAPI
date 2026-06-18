using TorontoRiskAPI.Models;

namespace TorontoRiskAPI.Services.Interfaces
{
    public interface ISchoolService
    {
        Task<IEnumerable<School>> GetAllAsync();
        Task<IEnumerable<School>> GetAtRiskAsync();
    }
}
