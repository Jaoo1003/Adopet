using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Adopet___Alura_Challenge_6.Data.InferfaceDao
{
    public interface IPetDao : ICommand<PetDto>, IQuery<Pet>
    {
        bool UpdatePatch(int id, JsonPatchDocument<PetDto> pet);
    }
}
