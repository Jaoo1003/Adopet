using System.ComponentModel.DataAnnotations;

namespace Adopet___Alura_Challenge_6.Data.Dtos.Abrigo {
    public class CreateAbrigoDto {
        [Required]
        [StringLength(100, ErrorMessage = "O logradouro deve ter no máximo 100 caracteres")]
        public string Logradouro { get; set; }
        [Required]
        public int? Numero { get; set; } = null;
        [Required]
        public string Estado { get; set; }
    }
}
