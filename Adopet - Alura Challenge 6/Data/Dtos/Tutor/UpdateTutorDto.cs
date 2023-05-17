using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Adopet___Alura_Challenge_6.Data.Dtos.Tutor {
    public class UpdateTutorDto {
        [Required]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "O Email deve ter no máximo 100 caracteres")]
        public string Email { get; set; }
    }
}
