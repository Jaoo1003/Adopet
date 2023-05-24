using System.ComponentModel.DataAnnotations;

namespace Adopet___Alura_Challenge_6.Data.Dtos.Adocoes {
    public class ReadAdocaoDto {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int TutorId { get; set; }
        public DateTime Time { get; set; }
    }
}
