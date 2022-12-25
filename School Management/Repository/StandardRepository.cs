using Microsoft.EntityFrameworkCore;
using School_Management.Data;
using School_Management.Interface_Repository;
using School_Management.Models;

namespace School_Management.Repository
{
    public class StandardRepository : IStandardRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public StandardRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        public async Task<List<Standard>> GetStandards()
        {
            var standards = await _schoolDbContext.Standards.ToListAsync();
            return standards;
        }

        public async Task<Standard> GetStandardById(int id)
        {
            var standard = await _schoolDbContext.Standards.FirstOrDefaultAsync(x => x.StandardId == id);
            return standard!;
        }

        public async Task<Standard> AddStandard(Standard standard)
        {
            await _schoolDbContext.Standards.AddAsync(standard);
            await _schoolDbContext.SaveChangesAsync();
            return standard;
        }

        public async Task<Standard> DeleteStandardById(int id)
        {
            var standard = await _schoolDbContext.Standards.FirstOrDefaultAsync(x => x.StandardId == id);
            if (standard != null)
            {
                _schoolDbContext.Standards.Remove(standard);
                await _schoolDbContext.SaveChangesAsync();
            }
            return standard!;
        }
    }
}
