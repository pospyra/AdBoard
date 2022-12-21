using AdBoard.AppServices.Ad.Services;
using AdBoard.AppServices.Photos;
using Microsoft.AspNetCore.Mvc;
using SelectedAd.Contracts;
using SelectedAd.Contracts.Photo;
using SelectedAd.Domain;
using System.Net;
using System.Web;

namespace AdBoard.Api.Controllers
{

    [ApiController]
    [Route("v1/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        /// <summary>
        /// Добавить фото
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="image"></param>
        /// <param name="cancellation"></param>
        ///// <returns></returns>
        
        [HttpPost("addPhoto")]
        [ProducesResponseType(typeof(IReadOnlyCollection<CreatePhotoResponse>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddPhoto(IFormFile file, CancellationToken cancellationToken)
        {
            CreatePhotoResponse response;
            await using (var ms = new MemoryStream())
            await using (var fs = file.OpenReadStream())
            {
                await fs.CopyToAsync(ms, cancellationToken);

                  response = await _photoService.AddAdPhoto(new CreatePhotoRequest()
                {
                    Photo = ms.ToArray()
                }, cancellationToken);
            }

            return Ok();
        }

        /// <summary>
        /// Удалить фото
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeletePhoto(Guid id, CancellationToken cancellation)
        {
            await _photoService.DeleteAsync(id, cancellation);

            return NoContent();
        }
    }
}
