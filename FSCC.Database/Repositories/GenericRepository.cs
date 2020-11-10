using Microsoft.EntityFrameworkCore;
using FSCC.Database.Repositories.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FSCC.Models.Database.Entity;

namespace FSCC.Database.Repositories.Abstractions
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DatabaseContext _dbContext;

        public GenericRepository(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var createdEntity = await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public virtual async Task<TEntity> DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}
