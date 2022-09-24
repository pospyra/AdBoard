using Microsoft.AspNetCore.Mvc;
using SelectedAd.Contracts;
using System.Net;

namespace AdBoard.Api.Controllers
{ /// <summary>
  /// Работа с доской объявлений.
  /// </summary>

    [ApiController]
    [Route("v1/[controller]")]

    public class SelectedAdController : ControllerBase
    {
        public SelectedAdController()
        { 
        }
        /// <summary>
        /// Возвращает позиции объявлений с доски
        /// </summary>
        /// <returns>Коллекция элементов <see cref="SelectedAdDto"/> </returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<SelectedAdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync()
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// Обновляет количество объявлений на доске.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateQuantityAsync(int quantity)
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// Удаляет объявления на доски.
        /// </summary>
        /// <param name="Id">Индетификатор объявление на доске</param>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            return await Task.FromResult(Ok());
        }
    }
}