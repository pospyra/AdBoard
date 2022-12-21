using AdBoard.AppServices.Ad.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using SelectedAd.Contracts.Ad;
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
        public async Task<IActionResult> GetAll(CancellationToken cancellation, int take, int skip)
        {
            var result = await _adService.GetAll(cancellation, take, skip);

            return Ok(result);
        }

        /// <summary>
        /// Вернуть объявление по идентификатору 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getById")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(Guid id)
        {

            var result = await _adService.GetByIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Возвращает объявление по параметру
        /// </summary>
        /// <param name="AdName"></param>
        /// <param name="CategoryId"></param>
        /// <param name="PossibleOfDelivery"></param>
        /// <param name="Price"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("filterParam")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllFilter(Guid? userId, string? AdName, Guid? CategoryId, bool? PossibleOfDelivery, int take, int skip) {

            var result = await _adService.GetAdFiltered(userId, AdName, CategoryId, PossibleOfDelivery, take, skip);

            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AdName"></param>
        /// <param name="CategoryId"></param>
        /// <param name="PossibleOfDelivery"></param>
        /// <param name="Price"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("pageFilter")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAdFilter(AdFilterRequest request)
        {

            var result = await _adService.GetAllFiltered(request);

            return Ok(result);
        }

        /// <summary>
        /// Создать объявление
        /// </summary>
        /// <param name="createAd"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost("createAd")]
        [ProducesResponseType(typeof(IReadOnlyCollection<CreateAdDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAdAsync(CreateAdDto createAd, CancellationToken cancellation)
        {
            var user = await _userService.GetCurrentUserId(cancellation);

            var result = await _adService.CreateAdAsync(createAd, cancellation);

            return Created("", result);
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
        //[HttpPut("{id}")]
        //[ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.Created)]
        //public async Task<IActionResult> EditAdAsync(Guid id, string adName, Guid category, string description, decimal price, bool possibleOfDelivery, CancellationToken cancellation)
        //{
        //    var user = await _userService.GetCurrent(cancellation);

        //    await _adService.EditAdAsync( id,  adName,  category,  description,  price,  possibleOfDelivery);

        //    return NoContent();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adName"></param>
        /// <param name="category"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="possibleOfDelivery"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> EditAd2Async(EditAdDto edit, CancellationToken cancellation)
        {
            var user = await _userService.GetCurrent(cancellation);

            await _adService.EditAdAsync(edit);

            return NoContent();
        }

        /// <summary>
        /// Удаляет объявление
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns>NoContent</returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteUserAsync(Guid id, CancellationToken cancellation)
        {
            var user = await _userService.GetCurrent(cancellation);

            await _adService.DeleteAsync(id, cancellation);

            return NoContent();
        }




        /// <summary>
        /// Создать объявление
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="cancellation"></param>
        /// <returns>Created("", new { })</returns>
        //[Route("api/[controller]/[action]")]
        [HttpPost("create")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAdAsync(string adName, Guid categoryId, Guid subCategory, string description, decimal price, bool possibleOfDelivery, Guid userId, CancellationToken cancellation)
        {
            var user = await _userService.GetCurrentUserId(cancellation);

            var result = await _adService.CreateAdAsync(adName, categoryId, subCategory, description, price, possibleOfDelivery, userId, cancellation);

            return Created("", new { });
        }




        /*
        [AllowAnonymous]
        [HttpGet("filterParambexPaging")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllFilter(string AdName, Guid CategoryId, bool PossibleOfDelivery, decimal Price)
        {

            var result = await _adService.GetAdFiltered(AdName, CategoryId, PossibleOfDelivery, Price);

            return Ok(result);
        }*/



        /*
          /// <summary>
        /// Объявление по фильтру
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("filterRequest")]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllFilter(AdFilterRequest request)
        {
            var result =  _adService.GetAllFiltered(request );

            return Ok(result);
        }*/

        /*
/// <summary>
/// Возвращает Страницы Объявления
/// </summary>
/// <param name="pagging"></param>
/// <returns></returns>
[HttpGet("pagging")]
[ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.OK)]
public async Task<IActionResult> GetAll(PagingFilter pagging)
{
    var result = await _adService.GetAll(pagging);

    return Ok(result);
}*/

        /*
/// <summary>
/// Создать объявление
/// </summary>
/// <param name="take"></param>
/// <param name="skip"></param>
/// <param name="cancellation"></param>
/// <returns>Created("", new { })</returns>
//[Route("api/[controller]/[action]")]
[HttpPost()]
[ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.Created)]
public async Task<IActionResult> CreateAdAsync(string adName, Guid categoryId, Guid subCategory, string description, decimal price, bool possibleOfDelivery, Guid userId, CancellationToken cancellation)
{
    var user = await _userService.GetCurrent(cancellation);

    var result = await _adService.CreateAdAsync(adName, categoryId, subCategory, description, price, possibleOfDelivery, userId);

    return Created("", new { });
}*/
    }
}       
