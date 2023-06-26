using Adopet.Tests.Helper;
using Adopet___Alura_Challenge_6.Data.Dtos.Adocoes;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

namespace Adopet.Tests.Services {
    public class AdocaoServiceTests {
        private readonly Mock<AppDbContext> mockDbContext;
        private readonly Mock<DbSet<Adocao>> mockSetAdocao;

        public AdocaoServiceTests() {
            mockDbContext = new Mock<AppDbContext>();
            mockSetAdocao = TestDataHelper.FakeAdocaoList().BuildMock().BuildMockDbSet();
        }


        [Fact]
        public void Post_CreateValidAdocao() {

            //Arrange
            mockDbContext.Setup(x => x.Pets.Find(1)).Returns(TestDataHelper.FakePetList().Find(p => p.Id == 1));
            mockDbContext.Setup(x => x.Tutores.Find(1)).Returns(TestDataHelper.FakeTutorList().Find(t => t.Id == 1));

            //Act
            var adocaoDao = CreateAdocaoDaoEfCoreObject();
            var result = adocaoDao.Create(new AdocaoDto { PetId = 1, TutorId = 1});

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Post_TryCreateAdocaoWithInvalidPetIdAndTutorId() {

            //Arrange
            mockDbContext.Setup(x => x.Pets.Find(3)).Returns(TestDataHelper.FakePetList().Find(p => p.Id == 3));
            mockDbContext.Setup(x => x.Tutores.Find(3)).Returns(TestDataHelper.FakeTutorList().Find(t => t.Id == 3));

            //Act
            var adocaoDao = CreateAdocaoDaoEfCoreObject();

            //Assert

            var result = Assert.Throws<ArgumentException>( () => adocaoDao.Create(new AdocaoDto { PetId = 3, TutorId = 3 }));
            Assert.Equal("tutor e/ou pet inexistentes", result.Message);
        }

        [Fact]
        public void Get_GetAllAdocoes() {

            //Arrange
            mockDbContext.Setup(x => x.Adocoes).Returns(mockSetAdocao.Object);

            //Act
            var adocaoDao = CreateAdocaoDaoEfCoreObject();
            var result = adocaoDao.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Get_GetAdocaoByValidId() {

            //Arrange
            mockDbContext.Setup(x => x.Adocoes.Find(1)).Returns(TestDataHelper.FakeAdocaoList().Find(a => a.Id == 1));

            //Act
            var adocaoDao = CreateAdocaoDaoEfCoreObject();
            var result = adocaoDao.GetById(1);

            //Assert
            Assert.NotNull (result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Get_GetAdocaoByInvalidId() {

            //Arrange
            mockDbContext.Setup(x => x.Adocoes.Find(3)).Returns(TestDataHelper.FakeAdocaoList().Find(a => a.Id == 3));

            //Act
            var adocaoDao = CreateAdocaoDaoEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => adocaoDao.GetById(3));
            Assert.Equal("Adoção Não Encontrada", result.Message);
        }

        [Fact]
        public void Update_UpdateAbrigoWithValidModelStateObjectAndAdocaoId() {

            //Arrange
            mockDbContext.Setup(x => x.Adocoes.Find(1)).Returns(TestDataHelper.FakeAdocaoList().Find(a => a.Id == 1));

            //Act
            var adocaoDao = CreateAdocaoDaoEfCoreObject();
            var adocaoUpdate = new AdocaoDto { PetId = 2, TutorId = 2 };
            var result = adocaoDao.Update(adocaoUpdate, 1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Update_TryUpdateWithValidModelStateObjectAndInvalidAdocaoId() {

            //Arrange
            mockDbContext.Setup(x => x.Adocoes.Find(3)).Returns(TestDataHelper.FakeAdocaoList().Find(a => a.Id == 3));

            //Act
            var adocaoDao = CreateAdocaoDaoEfCoreObject();
            var adocaoUpdate = new AdocaoDto { PetId = 2, TutorId = 2 };

            //Assert
            var result = Assert.Throws<ArgumentException>( () => adocaoDao.Update(adocaoUpdate, 3));
            Assert.Equal("Adoção Não Encontrada", result.Message);
        }

        [Fact]
        public void Update_TryUpdateWithInvalidModelStateObject() {

            //Arrange
            mockDbContext.Setup(x => x.Adocoes.Find(1)).Returns(TestDataHelper.FakeAdocaoList().Find(a => a.Id == 1));

            //Act
            var adocaoDao = CreateAdocaoDaoEfCoreObject();
            var adocaoUpdate = new AdocaoDto { TutorId = 2 };

            //Assert
            var result = Assert.Throws<ArgumentException>(() => adocaoDao.Update(adocaoUpdate, 1));
            Assert.Equal("Verifique se os campos PetId e TutorId foram preenchidos corretamente", result.Message);
        }

        [Fact]
        public void Delete_DeleteAbrigoWithValidAbrigoId() {

            //Arrange
            mockDbContext.Setup(x => x.Adocoes.Find(1)).Returns(TestDataHelper.FakeAdocaoList().Find(a => a.Id == 1));

            //Act
            var adocaoDao = CreateAdocaoDaoEfCoreObject();
            var result = adocaoDao.Delete(1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_DeleteAbrigoWithInvalidAbrigoId() {

            //Arrange
            mockDbContext.Setup(x => x.Adocoes.Find(3)).Returns(TestDataHelper.FakeAdocaoList().Find(a => a.Id == 3));

            //Act
            var adocaoDao = CreateAdocaoDaoEfCoreObject();


            //Assert
            var result = Assert.Throws<ArgumentException>( () => adocaoDao.Delete(3));
            Assert.Equal("Adoção Não Encontrada", result.Message);
        }

        public AdocaoDaoComEfCore CreateAdocaoDaoEfCoreObject() {
            return new(mockDbContext.Object, new Mock<IMapper>().Object);
        }
    }
}