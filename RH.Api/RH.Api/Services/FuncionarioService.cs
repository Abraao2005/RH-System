using Microsoft.EntityFrameworkCore;
using RH.Api.Data;
using RH.Api.Dtos;
using RH.Api.Models;

namespace RH.Api.Services
{
    public class FuncionarioService
    {
        private readonly DbContextAplication _context;
        public FuncionarioService(DbContextAplication context) {
        _context = context;
        }
        public async Task<ServiceResponse<FuncionarioModel>> BuscarPorId(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                return new ServiceResponse<FuncionarioModel>(null, "Funcionário não encontrado");
            }

            return new ServiceResponse<FuncionarioModel>(funcionario, "Funcionário encontrado");
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> BuscarFuncionarios()
        {
            List<FuncionarioModel> lista = await  _context.Funcionarios.ToListAsync();
            return new ServiceResponse<List<FuncionarioModel>>(lista, "Lista de funcionarios");
        }
        public async Task<ServiceResponse<List<FuncionarioModel>>> BuscarPorCargoFuncionario(string cargo)
        {
            var funcionarios = await _context.Funcionarios.Where(f => f.Office.Contains(cargo)).ToListAsync();

            if (funcionarios == null)
            {
                return new ServiceResponse<List<FuncionarioModel>>(null, "Funcionário não encontrado");
            }

            return new ServiceResponse<List<FuncionarioModel>>(funcionarios, "Funcionário encontrado");
        }


        public async Task<ServiceResponse<FuncionarioModel>> SalvarFuncionario(FuncionarioDto funcionario)
        {

            FuncionarioModel fun = FuncionarioModel.ToModel(funcionario);

            _context.Add(fun);
            await _context.SaveChangesAsync();
            return new ServiceResponse<FuncionarioModel>
            {
                Data = fun,
                Message = "Funcionário cadastrado com sucesso"
            };
        }

        public async Task<ServiceResponse<bool>> DeletarFuncionario(int id)
        {

           FuncionarioModel? funcionario =  await _context.Funcionarios.FindAsync(id);

            if(funcionario == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = "Funcionário não encontrado",
                };
            }


            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Funcionário deletado com sucesso",
            };
        }


        public async Task<ServiceResponse<bool>> AtualizarFuncionario(int id, FuncionarioDto funcionarioAtualizado)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = "Funcionário não encontrado",
                };
            }

            funcionario.Active = funcionarioAtualizado.Active;
            funcionario.Office = funcionarioAtualizado.Office;
            funcionario.Name = funcionarioAtualizado.Name;
            funcionario.DateAdmission = funcionarioAtualizado.DateAdmission;
            funcionario.Salary = funcionarioAtualizado.Salary;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Funcionário atualizado com sucesso",
            };
        }

    }
}
