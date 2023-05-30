using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Models;

namespace Adopet___Alura_Challenge_6.Data.Dtos.Pets {
    public class ReadPetDto {
        public int Id { get; set; }
        public int AbrigoId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Porte { get; set; }
        public string Personalidade { get; set; }
        public bool Adotado { get; set; }
        public string Endereco { get; set; }
        public string Imagem { get; set; }
    }
}
