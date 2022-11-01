using AdBoard.AppServices.Photos;
using Microsoft.AspNetCore.Mvc;
using SelectedAd.Contracts;
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
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IReadOnlyCollection<PhotoDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddPhotoAsync(Photo photo, IFormFile image, CancellationToken cancellation)
        {
            photo.ImageMimeType = image.ContentType;
            photo.LinkPhoto = new byte[image.Length];

            await _photoService.AddAPhotosync(photo, cancellation);

            return Created("", new { });
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
