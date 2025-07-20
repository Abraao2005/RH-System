using Microsoft.AspNetCore.Mvc;
using RH.Api.Dtos;
using RH.Api.Services;

namespace RH.Api.Controllers
{
    [ApiController]
    [Controller]
    [Route("api/[controller]")]
    public class SalarioController : Controller
    {
        private readonly SalarioService _service;

        public SalarioController(SalarioService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ServiceResponse<MediaSalarialDto>> Index()
        {
            float media = await _service.CalculaMediaSalario();

            var dto = new MediaSalarialDto
            {
                Media = media
            };

            return new ServiceResponse<MediaSalarialDto>
            {
                Data = dto,
                Message = "Média calculada com sucesso!"
            };
        }
    }
}
