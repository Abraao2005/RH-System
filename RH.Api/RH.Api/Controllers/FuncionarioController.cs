using Microsoft.AspNetCore.Mvc;
using RH.Api.Dtos;
using RH.Api.Models;
using RH.Api.Services;

namespace RH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioService _service;

        public FuncionarioController(FuncionarioService service)
        {
            _service = service;
        }
        [HttpGet("cargo/{cargo}")]
        public async Task<IActionResult> findWithOffice(string cargo)
        {
            var funcionarios = await _service.BuscarPorCargoFuncionario(cargo);
            return Ok(funcionarios);
        }
        [HttpGet]
        public async Task<IActionResult> findAll()
        {
            var funcionarios = await _service.BuscarFuncionarios();
            return Ok(funcionarios);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> findById(int id)
        {
            var funcionarios = await _service.BuscarPorId(id);
            return Ok(funcionarios);
        }

        [HttpPost]
        public async Task<IActionResult> save([FromBody] FuncionarioDto funcionario)
        {
            var funcionarios = await _service.SalvarFuncionario(funcionario);

            return Ok(funcionarios);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id,[FromBody] FuncionarioDto funcionario)
        {
            var funcionarios = await _service.AtualizarFuncionario(id,funcionario);

            return Ok(funcionarios);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var funcionarios = await _service.DeletarFuncionario(id);

            return Ok(funcionarios);
        }
    }
}
