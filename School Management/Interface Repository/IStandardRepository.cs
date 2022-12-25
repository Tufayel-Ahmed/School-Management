using School_Management.Models;

namespace School_Management.Interface_Repository
{
    public interface IStandardRepository
    {
        Task<List<Standard>> GetStandards();

        Task<Standard> GetStandardById(int id);

        Task<Standard> AddStandard(Standard standard);

        Task<Standard> DeleteStandardById(int id);
    }
}
