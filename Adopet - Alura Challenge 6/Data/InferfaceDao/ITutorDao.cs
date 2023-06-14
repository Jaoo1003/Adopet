
using Adopet___Alura_Challenge_6.Data.Dtos.Tutors;
using Adopet___Alura_Challenge_6.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Adopet___Alura_Challenge_6.Data.InferfaceDao
{
    public interface ITutorDao : ICommand<TutorDto>, IQuery<Tutor>
    {
        void UpdatePatch(int id, JsonPatchDocument<TutorDto> tutor);
    }
}
