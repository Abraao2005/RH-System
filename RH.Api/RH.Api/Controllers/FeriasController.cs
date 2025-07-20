using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.Api.Dtos;
using RH.Api.Models;
using RH.Api.Services;

namespace RH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeriasController : ControllerBase
    {
        private readonly FeriasService _service;

        public FeriasController(FeriasService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> Get() {
            ServiceResponse<List<FeriasModel>> response = await _service.ListarFeriasAsync();

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CriarFeriasDto dto)
        {
            var response = await  _service.CadastrarFeriasAsync(dto);
            
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] FeriasPutDto dto)
        {
            var response = await _service.AtualizarFeriasAsync(id, dto);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _service.DeletarFeriasAsync(id);
            return Ok(response);
        }
    }
}
