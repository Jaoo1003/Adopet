using Adopet___Alura_Challenge_6.Data.Dtos.Adocoes;
using Adopet___Alura_Challenge_6.Models;

namespace Adopet___Alura_Challenge_6.Data.InferfaceDao
{
    public interface IAdocaoDao : ICommand<AdocaoDto>, IQuery<Adocao>
    {
        bool VerifyIfTutorAndPetExists(int? tutorId, int? petId);
    }
}
