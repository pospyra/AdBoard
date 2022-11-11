using AdBoard.AppServices.Ad.Services;
using AdBoard.AppServices.SelectedAd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelectedAd.Contracts;
using System.Net;

namespace AdBoard.Api.Controllers
{
    /// <summary>
    /// Работа с Избранными объявлениями.
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Route("v1/[controller]")]
    //[Route("v1/[controller]")]

    public class SelectedAdController : ControllerBase
    {
        private readonly ISelectedAdService _selectedAdService;
        private readonly IUserService _userService;

        public SelectedAdController(ISelectedAdService selectedAdService, IUserService userService)
        {
            _selectedAdService = selectedAdService;
            _userService = userService;
        }

        /// <summary>
        /// Возвращает позиции избранных объявлений
        /// </summary>
        /// <returns>Коллекция элементов <see cref="SelectedAdDto"/> </returns>
        // [Route("api/[controller]/[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<SelectedAdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync(CancellationToken cancellation)
        {

            //var user = await _userService.GetCurrent(cancellation); 

            var result = await _selectedAdService.GetAsync(cancellation);

            return Ok(result);
        }

        /// <summary>
        /// Создает вкладку Избранные объявления
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
       // [Route("api/[controller]/[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(IReadOnlyCollection<SelectedAdDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> PostAsync(Guid userId ,Guid adId, CancellationToken cancellation)
        {
            var user = await _userService.GetCurrent(cancellation);

            var result = await _selectedAdService.CreateSelectedAsync( userId, adId, cancellation);

            return Ok(result);
        }

        /// <summary>
        /// Удаляет вкладку избранных.
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

        /// <summary>
        /// Обновляет количество избранных объявлений.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateQuantityAsync(Guid id, int quantity, CancellationToken cancellation)
        {
            await _selectedAdService.UpdateQuantityAsync(id, quantity, cancellation);
            return NoContent();
        }


        /// <summary>
        /// Добавить Объявление в Избранные
        /// </summary>
        /// <param name="selectedId"></param>
        /// <param name="adId"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [Route("api/[controller]/[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(IReadOnlyCollection<SelectedAdDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddToSelected(Guid selectedId, Guid adId, CancellationToken cancellation)
        {
            //var user = await _userService.GetCurrent(cancellation);

             await _selectedAdService.AddItemSelected(selectedId, adId, cancellation);

            return Ok();
        }


      
       
        /// <summary>
        /// Удаляет объявление из Избранных
        /// </summary>
        /// <param name="selectedId"></param>
        /// <param name="adId"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [Route("api/[controller]/[action]")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> RemoveAdFromSelected(Guid selectedId, Guid adId, CancellationToken cancellation)
        {
            await _selectedAdService.RemoveItemSelected( selectedId,  adId,  cancellation);
            return NoContent();
        }
    }
}