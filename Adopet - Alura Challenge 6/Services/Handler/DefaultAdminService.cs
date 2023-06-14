using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Data.Dtos.Adocoes;
using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Data.Dtos.Tutors;
using Adopet___Alura_Challenge_6.Data.InferfaceDao;
using Adopet___Alura_Challenge_6.Models;

namespace Adopet___Alura_Challenge_6.Services.Handler {
    public class DefaultAdminService : IAdminService {

        private readonly IAbrigoDao _abrigoDao;
        private readonly IAdocaoDao _adocaoDao;
        private readonly IPetDao _petDao;
        private readonly ITutorDao _torDao;

        public DefaultAdminService(IAbrigoDao abrigoDao, IAdocaoDao adocaoDao, IPetDao petDao, ITutorDao torDao) {
            _abrigoDao = abrigoDao;
            _adocaoDao = adocaoDao;
            _petDao = petDao;
            _torDao = torDao;
        }

        #region Abrigo

        public IEnumerable<Abrigo> GetAllAbrigos() {
            return _abrigoDao.GetAll();
        }
        public Abrigo GetAbrigoById(int id) {
            return _abrigoDao.GetById(id);
        }
        public void CreateAbrigo(AbrigoDto abrigo) {
            _abrigoDao.Create(abrigo);
        }
        public void UpdateAbrigo(AbrigoDto abrigo, int id) {
            _abrigoDao.Update(abrigo, id);
        }
        public void DeleteAbrigo(int id) {
            _abrigoDao.Delete(id);
        }

        #endregion

        #region Adocao

        public IEnumerable<Adocao> GetAllAdocoes() {
            return _adocaoDao.GetAll();
        }
        public Adocao GetAdocoById(int id) {
            return _adocaoDao.GetById(id);
        }
        public void CreateAdocao(AdocaoDto adocao) {
            _adocaoDao.Create(adocao);
        }
        public void UpdateAdocao(AdocaoDto adocao, int id) {
            _adocaoDao.Update(adocao, id);
        }
        public void DeleteAdocao(int id) {
            _adocaoDao.Delete(id);
        }

        #endregion

        #region Pet
        
        public IEnumerable<Pet> GetAllPets() {
            return _petDao.GetAll();
        }
        public Pet GetPetById(int id) {
            return _petDao.GetById(id);
        }
        public void CreatePet(PetDto pet) {
            _petDao.Create(pet);
        }
        public void UpdatePet(PetDto pet, int id) {
            _petDao.Update(pet, id);
        }
        public void DeletePet(int id) {
            _petDao.Delete(id);
        }

        #endregion

        #region Tutor

        public IEnumerable<Tutor> GetAllTutor() {
            return _torDao.GetAll();
        }
        public Tutor GetTutorById(int id) {
            return _torDao.GetById(id);
        }
        public void CreateTutor(TutorDto tutor) {
            _torDao.Create(tutor);
        }
        public void UpdateTutor(TutorDto tutor, int id) {
            _torDao.Update(tutor, id);
        }
        public void DeleteTutor(int id) {
            _torDao.Delete(id);
        }

        #endregion  
    }
}
