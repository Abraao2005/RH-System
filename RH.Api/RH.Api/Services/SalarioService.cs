using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RH.Api.Data;

namespace RH.Api.Services
{
    public class SalarioService
    {
         private readonly DbContextAplication _context;
        public SalarioService(DbContextAplication context)
        {
            _context = context;
        }

        public async Task<float> CalculaMediaSalario()
        {
            float media = await _context.Funcionarios.AverageAsync(f => f.Salary);
            return media;
        }
    }
}
