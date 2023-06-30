using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Data.Dtos.Adocoes;
using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Data.Dtos.Tutors;
using Adopet___Alura_Challenge_6.Models;
using Newtonsoft.Json.Bson;

namespace Adopet___Alura_Challenge_6.Services {
    public interface IAdminService {

        IEnumerable<Abrigo> GetAllAbrigos(int skip);
        IEnumerable<Adocao> GetAllAdocoes(int skip);
        IEnumerable<Pet> GetAllPets(int skip);
        IEnumerable<Tutor> GetAllTutor(int skip);
        Abrigo GetAbrigoById(int id);
        Adocao GetAdocoById(int id);
        Pet GetPetById(int id);
        Tutor GetTutorById(int id);
        bool CreateAbrigo(AbrigoDto abrigo);
        bool UpdateAbrigo(AbrigoDto abrigo, int id);
        bool DeleteAbrigo(int id);
        bool CreateAdocao(AdocaoDto adocao);
        bool UpdateAdocao(AdocaoDto adocao, int id);
        bool DeleteAdocao(int id);
        bool CreatePet(PetDto pet);
        bool UpdatePet(PetDto pet, int id);
        bool DeletePet(int id);
        bool CreateTutor(TutorDto tutor);
        bool UpdateTutor(TutorDto tutor, int id);
        bool DeleteTutor(int id);
    }
}
