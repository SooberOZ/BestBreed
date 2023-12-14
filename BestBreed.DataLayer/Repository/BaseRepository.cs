using BestBreed.Contracts;
using BestBreed.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BestBreed.DataLayer.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BestBreedContext _context;
        public BaseRepository(BestBreedContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync<TEntity>(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync<TEntity>(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<TEntity>()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById<TEntity>(Guid id)
        {
            return _context.Set<T>().SingleOrDefault(i => i.Id == id)!;
        }

        public async Task<T> UpdateAsync<TEntity>(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
