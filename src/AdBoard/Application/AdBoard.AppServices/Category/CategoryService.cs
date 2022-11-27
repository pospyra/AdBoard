using SelectedAd.Contracts;
using SelectedAd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.AppServices.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> CreateCategoryAsync( string name)
        {
            var category = new Categories
            {
                Name = name
            };

            await _categoryRepository.AddAsync(category);

            return category.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            await _categoryRepository.DeleteAsync(id, cancellation);
        }

        public async Task EditCategoryAsync(Guid id, string name, CancellationToken cancellation)
        {
             await _categoryRepository.EditAsync(id, name, cancellation);
        }

        public  Task<IReadOnlyCollection<Categories>> GetAllCategory(CancellationToken cancellation)
        {
            return _categoryRepository.GetAll(cancellation);
        }

        Task<IReadOnlyCollection<SubCategoryDto>> ICategoryService.GetAllSubCategory(CancellationToken cancellation)
        {
            return _categoryRepository.GetAllSubCategory(cancellation);
        }

        /*
        public async Task<Guid> AddSubCategoryAsync(Guid categoryId,string nameSub, Guid subId)
        {
           
        }*/

    }
}
