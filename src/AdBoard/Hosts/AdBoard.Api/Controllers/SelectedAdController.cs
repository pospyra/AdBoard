using AdBoard.AppServices.Ad.Services;
using AdBoard.AppServices.SelectedAd.Services;
using Microsoft.AspNetCore.Mvc;
using SelectedAd.Contracts;
using System.Net;

namespace AdBoard.Api.Controllers
{ 
  /// <summary>
  /// Работа с Избранными объявлениями.
  /// </summary>

    [ApiController]

    [Route("v1/[controller]")]

    public class SelectedAdController : ControllerBase
    {
        private readonly ISelectedAdService _selectedAdService;

        public SelectedAdController(ISelectedAdService selectedAdService)
        {
            _selectedAdService = selectedAdService;
        }

        public SelectedAdController()
        { 
        }
        /// <summary>
        /// Возвращает позиции избранных объявлений
        /// </summary>
        /// <returns>Коллекция элементов <see cref="SelectedAd.Contracts.SelectedAdDto"/> </returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<SelectedAd.Contracts.SelectedAdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync( CancellationToken cancellation)
        {
            var result = await _selectedAdService.GetAsync(cancellation);
            return Ok(result);        }

        /// <summary>
        /// Обновляет количество избранных объявлений.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateQuantityAsync(Guid id, int quantity,CancellationToken cancellation)
        {
            await _selectedAdService.UpdateQuantityAsync(id, quantity, cancellation);
            return NoContent();
        }

        /// <summary>
        /// Удаляет объявление из избранных.
        /// </summary>
        /// <param name="Id">Индетификатор объявления на доске</param>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellation)
        {
            await _selectedAdService.DeleteAsync(id, cancellation);
            return NoContent();
        }
    }
}