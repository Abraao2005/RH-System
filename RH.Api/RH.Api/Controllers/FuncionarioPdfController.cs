using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RH.Api.Data;
using RH.Api.Services;
using System;

namespace RH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioPdfController : ControllerBase
    {
        private readonly DbContextAplication _context;

        public FuncionarioPdfController(DbContextAplication context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GerarRelatorioFuncionarios()
        {
            var funcionarios = _context.Funcionarios.ToList();
            var relatorio = new FuncionarioPdfService(funcionarios);
            var pdfBytes = relatorio.GerarPdf();
            return File(pdfBytes, "application/pdf","relatorio-funcionarios.pdf");
        }
    }
}
