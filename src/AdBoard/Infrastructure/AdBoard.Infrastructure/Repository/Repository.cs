using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdBoard.Infrastructure.Repository
{
    /// <inheritdoc />
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext DbContext { get; }

        protected DbSet <TEntity> DbSet { get; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="Repository"/>.
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public Repository(DbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }

        /// <inheritdoc />
        public async Task AddAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            await DbSet.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            DbSet.Remove(model);
            await DbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public async Task <IQueryable<TEntity>> GetAllAsync()
        {
            return DbSet;
        }



        /// <inheritdoc />
        public IQueryable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }
            return DbSet.Where(filter);
        }

        /// <inheritdoc />
        public async Task<TEntity> GetByIdAsync(Guid? Id)
        {
            return await DbSet.FindAsync(Id);
        }

        /// <inheritdoc />
        public async Task UpdateAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            DbSet.Update(model);
            await DbContext.SaveChangesAsync();
        }
    }
}

