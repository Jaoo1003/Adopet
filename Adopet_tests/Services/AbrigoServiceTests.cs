using Adopet.Tests.Helper;
using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

namespace Adopet.Tests.Services
{
    public class AbrigoServiceTests {
        private readonly Mock<AppDbContext> mockDbContext;
        private readonly Mock<DbSet<Abrigo>> mockSetAbrigo;

        public AbrigoServiceTests() {
            mockDbContext = new Mock<AppDbContext>();
            mockSetAbrigo = TestDataHelper.FakeAbrigoList().BuildMock().BuildMockDbSet();            
        }

        #region AbrigoTests

        [Fact]
        public void Post_CreatingValidAbrigo() {
            
            //Act
            var abrigoDao = CreateAbrigoDaoEfCoreObject();
            var abrigoResult = abrigoDao.Create(new AbrigoDto { Logradouro = "teste", Numero = 000, Estado = "SP"});

            //Assert
            Assert.True(abrigoResult);
        }

        [Fact]
        public void Post_TryCreatingInvalidAbrigo() {

            //Act
            var abrigoDao = CreateAbrigoDaoEfCoreObject();

            //Assert
            var exception = Assert.Throws<ArgumentException>(() => abrigoDao.Create(new AbrigoDto { Logradouro = "", Numero = null, Estado = "" }));
            Assert.Equal("Abrigo não Criado! Verifique se todos os campos foram preenchidos corretamente", exception.Message);
        }

        [Fact]
        public void Get_GetAllAbrigos() {

            //Arrange
            mockDbContext.Setup(x => x.Abrigos).Returns(mockSetAbrigo.Object);

            //Act
            var abrigoDao = CreateAbrigoDaoEfCoreObject();
            var abrigos = abrigoDao.GetAll();

            //Assert
            Assert.NotNull(abrigos);
            Assert.Equal(2, abrigos.Count());
        }

        [Fact]
        public void Get_GetAbrigoWithValidId() {

            //Arrange
            mockDbContext.Setup(x => x.Abrigos.Find(1)).Returns(TestDataHelper.FakeAbrigoList().Find(a => a.Id == 1));

            //Act
            var abrigoDao = CreateAbrigoDaoEfCoreObject();
            var abrigo = abrigoDao.GetById(1);

            //Assert
            Assert.NotNull(abrigo);
            Assert.Equal(1, abrigo.Id);
        }

        [Fact]
        public void Get_TryGetAbrigoWithInvalidId() {

            //Arrange
            mockDbContext.Setup(x => x.Abrigos.Find(3)).Returns(TestDataHelper.FakeAbrigoList().Find(a => a.Id == 3));

            //Act
            var abrigoDao = CreateAbrigoDaoEfCoreObject();
            var result = Assert.Throws<ArgumentException>(() => abrigoDao.GetById(3));

            //Assert
            Assert.Equal("Abrigo Não Encontrado", result.Message);
        }

        [Fact]
        public void Delete_DeleteAbrigoWithValidId() {

            //Arrange
            mockDbContext.Setup(x => x.Abrigos.Find(1)).Returns(TestDataHelper.FakeAbrigoList().Find(a => a.Id == 1));

            //Act
            var abrigoDao = CreateAbrigoDaoEfCoreObject();
            var result = abrigoDao.Delete(1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_DeleteAbrigoWithInvalidId() {

            //Arrange
            mockDbContext.Setup(x => x.Abrigos.Find(3)).Returns(TestDataHelper.FakeAbrigoList().Find(a => a.Id == 3));

            //Act
            var abrigoDao = CreateAbrigoDaoEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => abrigoDao.Delete(3));
            Assert.Equal("Abrigo Não Encontrado", result.Message);
        }

        [Fact]
        public void Update_UpdateAbrigoWithValidObjectModelAndValidId() {

            //Arrange
            mockDbContext.Setup(x => x.Abrigos.Find(1)).Returns(TestDataHelper.FakeAbrigoList().Find(a => a.Id == 1));
            var abrigo = new AbrigoDto { Logradouro = "rua teste", Numero = 123, Estado = "SP" };

            //Act
            var abrigoDao = CreateAbrigoDaoEfCoreObject();
            var result = abrigoDao.Update(abrigo, 1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Update_TryUpdateAbrigoWithInvalidObjectModelStateAndValidId() {

            //Arrange
            mockDbContext.Setup(x => x.Abrigos.Find(1)).Returns(TestDataHelper.FakeAbrigoList().Find(a => a.Id == 1));
            var abrigo = new AbrigoDto { Logradouro = null, Numero = 123, Estado = "SP" };

            //Act
            var abrigoDao = CreateAbrigoDaoEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => abrigoDao.Update(abrigo, 1));
            Assert.IsType<ArgumentException>(result);
            Assert.Equal("Verifique se Todos os campos foram preenchidos corretamente!", result.Message);
        }

        [Fact]
        public void Update_TryUpdateAbrigoWithValidObjectModelStateAndInvalidId() {

            //Arrange
            mockDbContext.Setup(x => x.Abrigos.Find(3)).Returns(TestDataHelper.FakeAbrigoList().Find(a => a.Id == 3));
            var abrigo = new AbrigoDto { Logradouro = null, Numero = 123, Estado = "SP" };

            //Act
            var abrigoDao = CreateAbrigoDaoEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => abrigoDao.Update(abrigo, 3));
            Assert.IsType<ArgumentException>(result);
            Assert.Equal("Verifique se Todos os campos foram preenchidos corretamente!", result.Message);
        }

        public AbrigoDaoComEfCore CreateAbrigoDaoEfCoreObject() {
            return new(mockDbContext.Object, new Mock<IMapper>().Object);
        }        

        #endregion
    }
}
