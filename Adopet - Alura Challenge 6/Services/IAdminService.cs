using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Data.Dtos.Adocoes;
using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Data.Dtos.Tutors;
using Adopet___Alura_Challenge_6.Models;
using Newtonsoft.Json.Bson;

namespace Adopet___Alura_Challenge_6.Services {
    public interface IAdminService {

        IEnumerable<Abrigo> GetAllAbrigos();
        IEnumerable<Adocao> GetAllAdocoes();
        IEnumerable<Pet> GetAllPets();
        IEnumerable<Tutor> GetAllTutor();
        Abrigo GetAbrigoById(int id);
        Adocao GetAdocoById(int id);
        Pet GetPetById(int id);
        Tutor GetTutorById(int id);
        void CreateAbrigo(AbrigoDto abrigo);
        void UpdateAbrigo(AbrigoDto abrigo, int id);
        void DeleteAbrigo(int id);
        void CreateAdocao(AdocaoDto adocao);
        void UpdateAdocao(AdocaoDto adocao, int id);
        void DeleteAdocao(int id);
        void CreatePet(PetDto pet);
        void UpdatePet(PetDto pet, int id);
        void DeletePet(int id);
        void CreateTutor(TutorDto tutor);
        void UpdateTutor(TutorDto tutor, int id);
        void DeleteTutor(int id);
    }
}
