using AdBoard.AppServices.Ad.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using SelectedAd.Contracts;
using SelectedAd.Domain;
using System.Net;
using System.Xml.Linq;

namespace AdBoard.Api.Controllers
{
    /// <summary>
    /// Работа с объявлениями.
    /// </summary>

    [ApiController]
    [Route("v1/[controller]")]
    [AllowAnonymous]

    public class AdController : ControllerBase
    {
        private readonly IAdService _adService;
        private readonly IUserService _userService;

        public AdController(IAdService adService, IUserService userService)
        {
            _adService = adService;
            _userService = userService;
        }

        /// <summary>
        /// Возвращает позиции всех объявлений.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="cancellation"></param>
        /// <returns>Ok(result)</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(int take, int skip, CancellationToken cancellation)
        {
            var result = await _adService.GetAll(take, skip, cancellation);

            return Ok(result);
        }

        /// <summary>
        /// Создать объявление
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="cancellation"></param>
        /// <returns>Created("", new { })</returns>
        //[Route("api/[controller]/[action]")]
        [HttpPost]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAdAsync(string adName, Guid categoryId, Guid subCategory, string description, decimal price, bool possibleOfDelivery, Guid userId, CancellationToken cancellation)
        {
            var user = await _userService.GetCurrent(cancellation);

            var result = await _adService.CreateAdAsync(adName, categoryId, subCategory, description, price, possibleOfDelivery, userId);

            return Created("", new { });
        }

        /// <summary>
        /// Редактирует объявление
        /// </summary>
        /// <param name="adName"></param>
        /// <param name="category"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="possibleOfDelivery"></param>
        /// <returns>NoContent</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> EditAdAsync(Guid id, string adName, Guid category, string description, decimal price, bool possibleOfDelivery, CancellationToken cancellation)
        {
            var user = await _userService.GetCurrent(cancellation);

            await _adService.EditAdAsync( id,  adName,  category,  description,  price,  possibleOfDelivery);

            return NoContent();
        }


        /// <summary>
        /// Удаляет объявление
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns>NoContent</returns>
        [HttpDelete]
       // [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteUserAsync(Guid id, CancellationToken cancellation)
        {
            var user = await _userService.GetCurrent(cancellation);

            await _adService.DeleteAsync(id, cancellation);

            return NoContent();
        }

                /*
        [Route("api/[controller]/[action]")]
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllFilter(AdFilterRequest request, CancellationToken cancellation)
        {
            var result = await _adService.GetAllFiltered(request, cancellation);

            return Ok(result);
        }*/
    }
}       
