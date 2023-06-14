using System.ComponentModel.DataAnnotations;

namespace Adopet___Alura_Challenge_6.Data.Dtos.Adocoes {
    public class AdocaoDto {
        [Required]
        public int PetId { get; set; }
        [Required]
        public int TutorId { get; set; }
    }
}
