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
        public bool CreateAbrigo(AbrigoDto abrigo) {
            return _abrigoDao.Create(abrigo);
        }
        public bool UpdateAbrigo(AbrigoDto abrigo, int id) {
            return _abrigoDao.Update(abrigo, id);
        }
        public bool DeleteAbrigo(int id) {
            return _abrigoDao.Delete(id);
        }

        #endregion

        #region Adocao

        public IEnumerable<Adocao> GetAllAdocoes() {
            return _adocaoDao.GetAll();
        }
        public Adocao GetAdocoById(int id) {
            return _adocaoDao.GetById(id);
        }
        public bool CreateAdocao(AdocaoDto adocao) {
            return _adocaoDao.Create(adocao);
        }
        public bool UpdateAdocao(AdocaoDto adocao, int id) {
            return _adocaoDao.Update(adocao, id);
        }
        public bool DeleteAdocao(int id) {
            return _adocaoDao.Delete(id);
        }

        #endregion

        #region Pet
        
        public IEnumerable<Pet> GetAllPets() {
            return _petDao.GetAll();
        }
        public Pet GetPetById(int id) {
            return _petDao.GetById(id);
        }
        public bool CreatePet(PetDto pet) {
            return _petDao.Create(pet);
        }
        public bool UpdatePet(PetDto pet, int id) {
            return _petDao.Update(pet, id);
        }
        public bool DeletePet(int id) {
            return _petDao.Delete(id);
        }

        #endregion

        #region Tutor

        public IEnumerable<Tutor> GetAllTutor() {
            return _torDao.GetAll();
        }
        public Tutor GetTutorById(int id) {
            return _torDao.GetById(id);
        }
        public bool CreateTutor(TutorDto tutor) {
            return _torDao.Create(tutor);
        }
        public bool UpdateTutor(TutorDto tutor, int id) {
            return _torDao.Update(tutor, id);
        }
        public bool DeleteTutor(int id) {
            return _torDao.Delete(id);
        }

        #endregion  
    }
}
