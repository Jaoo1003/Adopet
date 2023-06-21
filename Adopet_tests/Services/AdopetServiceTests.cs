using Adopet.Tests.Helper;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using System.Linq;

namespace Adopet.Tests.Services
{
    public class AdopetServiceTests {
        #region AbrigoTests

        [Fact]
        public void Post_CreatingValidAbrigo() {
            //Arrange
            var mock = TestDataHelper.GetFakeAbrigoList().BuildMock().BuildMockDbSet();
            var mockDbContext = new Mock<AppDbContext>();
            //Config que retorna os objetos de GetFakeAbrigoList ao invez do DbSet.Abrigos
            mockDbContext.Setup(x => x.Abrigos).Returns(mock.Object);

            //Act
            AbrigoDaoComEfCore abrigoDao = new(mockDbContext.Object, new Mock<IMapper>().Object);
            //Testa o método 
            var abrigos = abrigoDao.GetAll();

            //Assert
            Assert.NotNull(abrigos);
            Assert.Equal(2, abrigos.Count());
        }

        #endregion


    }
}
