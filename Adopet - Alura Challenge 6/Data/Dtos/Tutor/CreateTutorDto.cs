using System.ComponentModel.DataAnnotations;

namespace Adopet___Alura_Challenge_6.Data.Dtos.Tutor {
    public class CreateTutorDto {
        [Required]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
