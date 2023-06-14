using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Models;

namespace Adopet___Alura_Challenge_6.Data.InferfaceDao
{
    public interface IAbrigoDao : ICommand<AbrigoDto>, IQuery<Abrigo>
    {
    }
}
