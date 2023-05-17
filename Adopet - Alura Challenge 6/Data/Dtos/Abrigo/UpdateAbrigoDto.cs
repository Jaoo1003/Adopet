using System.ComponentModel.DataAnnotations;

namespace Adopet___Alura_Challenge_6.Data.Dtos.Abrigo {
    public class UpdateAbrigoDto {
        [Required]
        [StringLength(100, ErrorMessage = "O logradouro deve ter no máximo 100 caracteres")]
        public string Logradouro { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}
