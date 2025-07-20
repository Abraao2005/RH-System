using RH.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace RH.Api.Dtos
{
    public class FuncionarioDto
    {
            public string Name { get; set; }
            public string Office { get; set; }

            public DateTime DateAdmission { get; set; }
            public bool Active { get; set; }
            
        public float Salary { get; set; }

    }
}
