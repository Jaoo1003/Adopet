using System.ComponentModel.DataAnnotations;

namespace Adopet___Alura_Challenge_6.Data.Dtos.Pets {
    public class PatchPetDto {
        public int AbrigoId { get; set; }
        public string Nome { get; set; }
        [Range(1, 50, ErrorMessage = "A idade do pet deve ser entre 0 e 50")]
        public int Idade { get; set; }
        public string Porte { get; set; }
        public string Personalidade { get; set; }
        public bool Adotado { get; set; }
        public string Endereco { get; set; }
        public string Imagem { get; set; }
    }
}
