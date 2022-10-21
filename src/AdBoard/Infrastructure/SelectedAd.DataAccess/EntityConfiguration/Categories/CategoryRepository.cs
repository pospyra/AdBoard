using AdBoard.AppServices.Category;
using AdBoard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using SelectedAd.Contracts;

namespace SelectedAd.DataAccess.EntityConfiguration.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<Domain.Categories> _repository;

        public CategoryRepository(IRepository<Domain.Categories> repository)
        {
            _repository = repository;
        }

        public Task AddAsync(Domain.Categories model)
        {
            return _repository.AddAsync(model);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            var existingCategory = await _repository.GetByIdAsync(id);

            await _repository.DeleteAsync(existingCategory);
        }

        public async Task EditAsync(Guid id, string name, CancellationToken cancellation)
        {
            var existingCategoty = await _repository.GetByIdAsync(id);
            if (existingCategoty == null)
            {
                throw new InvalidOperationException($"Категории с идентификатором {id} не существует");
            }
            existingCategoty.Name = name;

            await _repository.UpdateAsync(existingCategoty);
        }

        public async Task<IReadOnlyCollection<CategoryDto>> GetAll(CancellationToken cancellation)
        {
            return await _repository.GetAll()
              .Select(p => new CategoryDto
              {
                  Id = p.Id,
                  Name = p.Name
              }).ToListAsync(cancellation);
        }

    }
}
