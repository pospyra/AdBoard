
using AdBoard.AppServices.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelectedAd.Contracts;
using System.Net;

namespace AdBoard.Api.Controllers
{
    /// <summary>
    /// Работа с Категориями
    /// </summary>
    /// 
    [ApiController]
    [Route("v1/[controller]")]
    [AllowAnonymous]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Получить все категории
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<CategoryDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCategory( CancellationToken cancellation)
        {
            var result = await _categoryService.GetAllCategory(cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Создает категорию
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IReadOnlyCollection<CategoryDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateCategoryAsync(string name)
        {
            var result = await _categoryService.CreateCategoryAsync(name);

            return Created("", new { });
        }

        /// <summary>
        /// Редактировать категорию
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<CategoryDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditCategory(Guid id, string name, CancellationToken cancellation)
        {
            await _categoryService.EditCategoryAsync(id, name, cancellation);
            return NoContent();
        }

        /// <summary>
        /// Удалить категорию
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteCategoryAsync(Guid id, CancellationToken cancellation)
        {
            await _categoryService.DeleteAsync(id, cancellation);
            return NoContent();
        }
    }
}