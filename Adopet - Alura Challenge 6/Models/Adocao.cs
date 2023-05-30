using Adopet___Alura_Challenge_6.Data.Dtos.Tutors;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Adopet___Alura_Challenge_6.Models {
    public class Adocao {
        public int Id { get; set; }
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
        public int TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
