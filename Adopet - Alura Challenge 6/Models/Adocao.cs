﻿using Newtonsoft.Json;

namespace Adopet___Alura_Challenge_6.Models {
    public class Adocao {
        public int Id { get; set; }
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
        public int TutorId { get; set; }
        [JsonIgnore]
        public virtual Tutor Tutor { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
