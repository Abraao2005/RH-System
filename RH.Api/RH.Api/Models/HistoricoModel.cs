using System.ComponentModel.DataAnnotations;

namespace RH.Api.Models
{
    public class HistoricoModel
    {
        [Key]
        public int Id { get; set; }

        public string NomeEntidade { get; set; } 
        public int RegistroChave { get; set; } 
        public string CampoAlterado { get; set; }
        public string ValorAntigo { get; set; }
        public string ValorNovo { get; set; }
        public DateTime DataHora { get; set; }
    }

}
