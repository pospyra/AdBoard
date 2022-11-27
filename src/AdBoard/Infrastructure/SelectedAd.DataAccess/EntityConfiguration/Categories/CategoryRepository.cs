using AdBoard.AppServices.Category;
using AdBoard.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using SelectedAd.Contracts;
using SelectedAd.Domain;
using System;

namespace SelectedAd.DataAccess.EntityConfiguration.Categories
{
    /// <summary>
    /// Репозиторий для работы с Категориями и Подкатегориями
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<Domain.Categories> _repository;
        private readonly IRepository<Domain.SubCategory> _subrepository;

        public CategoryRepository(IRepository<Domain.Categories> repository, IRepository<Domain.SubCategory> subrepository)
        {
            _repository = repository;
            _subrepository = subrepository;
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

        public async Task<IReadOnlyCollection<Domain.Categories>> GetAll(CancellationToken cancellation)
        {
            return await _repository.GetAll()
              .Select(p => new Domain.Categories
              {
                  Name = p.Name,
                  Id = p.Id,
                  SubCategories =p.SubCategories,
              }).ToListAsync(cancellation);
        }

       public async Task<IReadOnlyCollection<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellation)
        {
            return await _subrepository.GetAll()
             .Select(p => new SubCategoryDto
             {
                 key = p.Id,
                  title = p.Name,
                //  CategoryId = p.CategoryId,
             }).ToListAsync(cancellation);
        }

        /*
        public async Task<Domain.Categories> AddSubCategoryAsync(Guid categoryId, string nameSub, Guid subId)
        {
            var category = _repository.GetByIdAsync(categoryId);
                if (category == null)
                    throw new Exception($"Категории с идетификатором {categoryId} не сущестует");

            category.A
            
            await _repository.AddAsync(category);

            return category;;
        }*/
    }
}
