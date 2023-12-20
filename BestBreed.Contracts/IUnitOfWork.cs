using Microsoft.EntityFrameworkCore;

namespace BestBreed.Contracts
{
    public interface IUnitOfWork<T> where T : DbContext
    {
        Task SaveChangesAsync();
    }
}