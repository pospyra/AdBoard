using AdBoard.AppServices.Ad.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using SelectedAd.Contracts;
using System.Net;

namespace AdBoard.Api.Controllers
{
    /// <summary>
    /// Работа с доской объявлений.
    /// </summary>

    [ApiController]
    [Route("v1/[controller]")]

    public class AdController : ControllerBase
    {
        private readonly IAdService _adService;

        public AdController(IAdService adService)
        {
            _adService = adService;
        }

        /// <summary>
        /// Возвращает позиции всех объявлений.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<AdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(int take, int skip, CancellationToken cancellation)
        {
            var result = await _adService.GetAll(take, skip, cancellation);

            return Ok(result);
        }
    }
}       
