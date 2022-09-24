using Microsoft.AspNetCore.Mvc;
using SelectedAd.Contracts;
using System.Net;

namespace AdBoard.Api.Controllers
{ /// <summary>
  /// ������ � ������ ����������.
  /// </summary>

    [ApiController]
    [Route("v1/[controller]")]

    public class SelectedAdController : ControllerBase
    {
        public SelectedAdController()
        { 
        }
        /// <summary>
        /// ���������� ������� ���������� � �����
        /// </summary>
        /// <returns>��������� ��������� <see cref="SelectedAdDto"/> </returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<SelectedAdDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync()
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// ��������� ���������� ���������� �� �����.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateQuantityAsync(int quantity)
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// ������� ���������� �� �����.
        /// </summary>
        /// <param name="Id">������������� ���������� �� �����</param>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            return await Task.FromResult(Ok());
        }
    }
}