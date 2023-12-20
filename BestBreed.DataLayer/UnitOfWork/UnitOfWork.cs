using BestBreed.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BestBreed.DataLayer.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        private readonly T _context;

        public UnitOfWork(T context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}