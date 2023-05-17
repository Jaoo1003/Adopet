using Microsoft.AspNetCore.Authorization;

namespace Adopet___Alura_Challenge_6.Models {
    public class Abrigo {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Estado { get; set; }
    }
}
