using Adopet___Alura_Challenge_6.Models;
using System.ComponentModel.DataAnnotations;

namespace Adopet___Alura_Challenge_6.Data.Dtos.Abrigos {
    public class AbrigoDto {
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public int? Numero { get; set; } = null;
        [Required]
        public string Estado { get; set; }
    }
}
