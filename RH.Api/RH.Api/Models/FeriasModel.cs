using RH.Api.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RH.Api.Models
{
    public class FeriasModel
    {
        [Key]
        public int Id { get; set; }

        public int FuncionarioId { get; set; }
        public FuncionarioModel Funcionario { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        [NotMapped]
        public string Status
        {
            get
            {
                var hoje = DateTime.Today;
                if (hoje >= DataInicio && hoje <= DataFim) return "Em andamento";
                if (DataInicio > hoje) return "Pendente";
                return "Concluídas";
            }
        }
        public static FeriasModel ToModel(CriarFeriasDto dto)
        {
            return new FeriasModel
            {
                FuncionarioId = dto.FuncionarioId,
                DataInicio = dto.DataInicio,
                DataFim = dto.DataTermino,
            };
        }
    }

}
