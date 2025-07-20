using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RH.Api.Data;
using RH.Api.Dtos;
using RH.Api.Models;

namespace RH.Api.Services
{
    public class FeriasService
    {
        private readonly DbContextAplication _context;
        public FeriasService(DbContextAplication context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<bool>> CadastrarFeriasAsync(CriarFeriasDto dto)
        {
            var funcionarioExiste = await _context.Funcionarios.AnyAsync(f => f.Id == dto.FuncionarioId);

            if (!funcionarioExiste)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = "Funcionário não encontrado.",
                };
            }

            var ferias = FeriasModel.ToModel(dto);
            _context.Ferias.Add(ferias);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Férias cadastradas com sucesso.",
            };
        }


        public async Task<ServiceResponse<List<FeriasModel>>> ListarFeriasAsync()
        {
            var ferias = await _context.Ferias.ToListAsync();

            return new ServiceResponse<List<FeriasModel>>(ferias, "Férias listadas com sucesso.");
        }

        public async Task<ServiceResponse<bool>> AtualizarFeriasAsync(int id, FeriasPutDto dto)
        {
            var ferias = await _context.Ferias.FindAsync(id);

            if (ferias == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = "Férias não encontradas."
                };
            }


            ferias.DataInicio = dto.DataInicio;
            ferias.DataFim = dto.DataTermino;

            _context.Ferias.Update(ferias);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Férias atualizadas com sucesso."
            };
        }
        public async Task<ServiceResponse<bool>> DeletarFeriasAsync(int id)
        {
            var ferias = await _context.Ferias.FindAsync(id);

            if (ferias == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = "Férias não encontradas."
                };
            }

            _context.Ferias.Remove(ferias);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Férias deletadas com sucesso."
            };
        }

    }
}
