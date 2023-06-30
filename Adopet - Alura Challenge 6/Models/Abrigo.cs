using Newtonsoft.Json;

namespace Adopet___Alura_Challenge_6.Models; 
public class Abrigo {
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public int Numero { get; set; }
    public string Estado { get; set; }
    [JsonProperty(Order = 5)]
    public virtual IEnumerable<Pet>? Pets { get; set; }
}