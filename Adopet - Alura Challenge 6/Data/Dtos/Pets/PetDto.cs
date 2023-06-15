using System.ComponentModel.DataAnnotations;

namespace Adopet___Alura_Challenge_6.Data.Dtos.Pets {
    public class PetDto {
        [Required]
        public int? AbrigoId { get; set; } = null;
        [Required]
        public string Nome { get; set; }
        [Required]
        [Range(1, 50, ErrorMessage = "A idade do pet deve ser entre 0 e 50")]
        public int Idade { get; set; }
        [Required]
        public string Porte { get; set; }
        [Required]
        public string Personalidade { get; set; }
        [Required]
        public bool Adotado { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        [RegularExpression(@"\b(?:https?://|www\.)\S+\b", ErrorMessage = "A URL não é válida.")]
        public string Imagem { get; set; }
    }
}