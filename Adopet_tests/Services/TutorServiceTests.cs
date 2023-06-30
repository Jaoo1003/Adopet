using Adopet.Tests.Helper;
using Adopet___Alura_Challenge_6.Data.Dtos.Tutors;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

namespace Adopet.Tests.Services {
    public class TutorServiceTests {
        private readonly Mock<AppDbContext> mockDbContext;
        private readonly Mock<DbSet<Tutor>> mockSetTutor;

        public TutorServiceTests() {
            mockDbContext = new Mock<AppDbContext>();
            mockSetTutor = TestDataHelper.FakeTutorList().BuildMock().BuildMockDbSet();
        }


        [Fact]
        public void Post_CreateValidTutor() {

            //Arrange
            var tutor = new TutorDto { Nome = "Fernando", Email = "fernando.testes@teste.com", Password = "Senha123!", RePassword = "Senha123!" };

            //Act
            var tutorDao = CreateTutorDaoComEfCoreObject();
            var result = tutorDao.Create(tutor);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Post_TryCreateTutorWithInvalidModelStateObject() {

            //Arrange
            var tutor = new TutorDto { Nome = "Fernando", Email = "fernando.teste@teste.com", Password = "Senha123!" };

            //Act
            var tutorDao = CreateTutorDaoComEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => tutorDao.Create(tutor));
            Assert.Equal("Verifique se todos os campos foram preenchidos corretamente", result.Message);
        }

        [Fact]
        public void Post_TryCreateTutorWithInvalidRePassword() {

            //Arrange
            var tutor = new TutorDto { Nome = "Fernando", Email = "fernando.teste@teste.com", Password = "Senha123!", RePassword = "WrongRePassword" };

            //Act
            var tutorDao = CreateTutorDaoComEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => tutorDao.Create(tutor));
            Assert.Equal("Verifique se a senha e a confirmação da senha são iguais", result.Message);
        }

        [Fact]
        public void Get_GetAllTutor() {

            //Arrange
            mockDbContext.Setup(x => x.Tutores).Returns(mockSetTutor.Object);

            //Act
            var tutorDao = CreateTutorDaoComEfCoreObject();
            var result = tutorDao.GetAll();

            //Assert    
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Get_GetTutorByValidId() {

            //Arrange
            mockDbContext.Setup(x => x.Tutores.Find(1)).Returns(TestDataHelper.FakeTutorList().Find(t => t.Id == 1));

            //Act
            var tutorDao = CreateTutorDaoComEfCoreObject();
            var result = tutorDao.GetById(1);

            //Assert    
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Get_TryGetTutorWithInvalidId() {

            //Arrange
            mockDbContext.Setup(x => x.Tutores.Find(3)).Returns(TestDataHelper.FakeTutorList().Find(t => t.Id == 3));

            //Act
            var tutorDao = CreateTutorDaoComEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => tutorDao.GetById(3));
            Assert.Equal("Tutor Não Encontrado", result.Message);
        }

        [Fact]
        public void Update_UpdateTutorWithValidTutoDtoModelStateAndTutoId() {

            //Arrange
            mockDbContext.Setup(x => x.Tutores.Find(1)).Returns(TestDataHelper.FakeTutorList().Find(t => t.Id == 1));
            var tutor = new TutorDto { Nome = "Fernando", Email = "fernando.testes@teste.com", Password = "Senha123!", RePassword = "Senha123!" };

            //Act
            var tutorDao = CreateTutorDaoComEfCoreObject();
            var result = tutorDao.Update(tutor, 1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Update_TryUpdateTutorWithValidTutorDtoModelStateAndInvalidTutorId() {

            //Arrange
            mockDbContext.Setup(x => x.Tutores.Find(3)).Returns(TestDataHelper.FakeTutorList().Find(t => t.Id == 3));
            var tutor = new TutorDto { Nome = "Fernando", Email = "fernando.testes@teste.com", Password = "Senha123!", RePassword = "Senha123!" };

            //Act
            var tutorDao = CreateTutorDaoComEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => tutorDao.Update(tutor, 3));
            Assert.Equal("Tutor Não Encontrado", result.Message);
        }

        [Fact]
        public void Update_TryUpdateTutorWithalidTutorDtoModelStateAndValidTutorId() {

            //Arrange
            mockDbContext.Setup(x => x.Tutores.Find(1)).Returns(TestDataHelper.FakeTutorList().Find(t => t.Id == 1));
            var tutor = new TutorDto { Nome = "Fernando", Password = "Senha123!", RePassword = "Senha123!" };

            //Act
            var tutorDao = CreateTutorDaoComEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => tutorDao.Update(tutor, 1));
            Assert.Equal("Verifique se todos os campos foram preenchidos corretamente", result.Message);
        }

        [Fact]
        public void Patch_PatchTutor() {

            //Arrange
            mockDbContext.Setup(x => x.Tutores.Find(1)).Returns(TestDataHelper.FakeTutorList().Find(t => t.Id == 1));
            var tutor = new JsonPatchDocument<TutorDto>();

            //Act
            var tutorDao = CreateTutorDaoComEfCoreObject();
            var result = tutorDao.UpdatePatch(1, tutor);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_DeleteTutorWithValidId() {

            //Arrange
            mockDbContext.Setup(x => x.Tutores.Find(1)).Returns(TestDataHelper.FakeTutorList().Find(t => t.Id == 1));

            //Act
            var tutorDao = CreateTutorDaoComEfCoreObject();
            var result = tutorDao.Delete(1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_DeleteTutorWithInvalidId() {

            //Arrange
            mockDbContext.Setup(x => x.Tutores.Find(3)).Returns(TestDataHelper.FakeTutorList().Find(t => t.Id == 3));

            //Act
            var tutorDao = CreateTutorDaoComEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => tutorDao.Delete(3));
            Assert.Equal("Tutor Não Encontrado", result.Message);
        }

        public TutorDaoComEfCore CreateTutorDaoComEfCoreObject() {
            return new(mockDbContext.Object, new Mock<IMapper>().Object);
        }
    }
}
