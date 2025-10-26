using Services.Tax.Domain.DataAccess;

namespace Services.Tax.Infrastructure.DataAccess
{
    public interface IPeriodRepository
    {
        Task<IEnumerable<Period>> GetAllAsync();

        Task<Period?> GetByIdAsync(int id);
    }
}
