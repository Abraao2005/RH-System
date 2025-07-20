using RH.Api.Dtos;
using System.ComponentModel.DataAnnotations;

namespace RH.Api.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Office { get; set; }

        public DateTime DateAdmission { get; set; }
        public bool Active { get; set; } = true;

        public float Salary { get; set; }


        public static FuncionarioModel ToModel(FuncionarioDto dto)
        {
            return new FuncionarioModel
            {
                Name = dto.Name,
                Office = dto.Office,
                DateAdmission = dto.DateAdmission,
                Active = dto.Active,
                Salary = dto.Salary,
            };
        }
    }
}
