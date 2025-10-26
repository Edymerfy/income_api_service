using Microsoft.EntityFrameworkCore;
using Services.Tax.Domain.DataAccess;

namespace Services.Tax.Infrastructure.DataAccess
{
    public class PeriodRepository : IPeriodRepository
    {
        private readonly AppDbContext _context;

        public PeriodRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Period>> GetAllAsync()
            => await _context.Period.ToListAsync();

        public async Task<Period?> GetByIdAsync(int id)
            => await _context.Period.FirstOrDefaultAsync(p => p.Id == id);
    }
}
