using Adopet.Tests.Helper;
using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Adopet.Tests.Services {
    public class PetServiceTests {
        private readonly Mock<AppDbContext> mockDbContext;
        private readonly Mock<DbSet<Pet>> mockSetPet;

        public PetServiceTests() {
            mockDbContext = new Mock<AppDbContext>();
            mockSetPet = TestDataHelper.FakePetList().BuildMock().BuildMockDbSet();
        }


        [Fact]
        public void Post_CreateValidPet() {

            //Act
            var pet = new PetDto {
                AbrigoId = 1,
                Nome = "Neymar",
                Idade = 4,
                Porte = "Junior",
                Personalidade = "Invocado",
                Adotado = false,
                Endereco = "rua teste",
                Imagem = "https://imagemdoneymarteste.com"
            };
            var petDao = CreatePetDaoComEfCoreObject();
            var result = petDao.Create(pet);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Post_TryCreatePetWithInvalidModelStateObject() {

            //Act
            var pet = new PetDto {
                Nome = "Neymar",
                Porte = "Junior",
                Personalidade = "",
                Adotado = false,
                Endereco = "rua teste",
                Imagem = "imagemdoneymarteste.com"
            };
            var petDao = CreatePetDaoComEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => petDao.Create(pet));
            Assert.Equal("Verifique se todos os campos foram preenchidos corretamente!", result.Message);
        }

        [Fact]
        public void Get_GetAllPets() {

            //Arrange
            mockDbContext.Setup(x => x.Pets).Returns(mockSetPet.Object);

            //Act
            var petDao = CreatePetDaoComEfCoreObject();
            var result = petDao.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void Get_GetPetByValidId() {

            //Arrange
            mockDbContext.Setup(x => x.Pets.Find(1)).Returns(TestDataHelper.FakePetList().Find(p => p.Id == 1));

            //Act
            var petDao = CreatePetDaoComEfCoreObject();
            var result = petDao.GetById(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Get_TryGetPetByInvalidId() {

            //Arrange
            mockDbContext.Setup(x => x.Pets.Find(3)).Returns(TestDataHelper.FakePetList().Find(p => p.Id == 3));

            //Act
            var petDao = CreatePetDaoComEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => petDao.GetById(3));
            Assert.Equal("Pet Não Encontrado", result.Message);
        }

        [Fact]
        public void Update_UpdatePetWithValidPetDtoModelStateObjectAndValidId() {

            //Arrange
            mockDbContext.Setup(x => x.Pets.Find(1)).Returns(TestDataHelper.FakePetList().Find(p => p.Id == 1));
            var pet = new PetDto {
                AbrigoId = 1,
                Nome = "Neymar",
                Idade = 4,
                Porte = "Junior",
                Personalidade = "Invocado",
                Adotado = false,
                Endereco = "rua teste",
                Imagem = "https://imagemdoneymarteste.com"
            };

            //Act
            var petDao = CreatePetDaoComEfCoreObject();
            var result = petDao.Update(pet, 1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Update_TryUpdatePetWithValidPetDtoModelStateObjectAndInvalidId() {

            //Arrange
            mockDbContext.Setup(x => x.Pets.Find(3)).Returns(TestDataHelper.FakePetList().Find(p => p.Id == 3));
            var pet = new PetDto {
                AbrigoId = 1,
                Nome = "Neymar",
                Idade = 4,
                Porte = "Junior",
                Personalidade = "Invocado",
                Adotado = false,
                Endereco = "rua teste",
                Imagem = "https://imagemdoneymarteste.com"
            };

            //Act
            var petDao = CreatePetDaoComEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>( () => petDao.Update(pet, 3));
            Assert.Equal("Pet Não Encontrado", result.Message);
        }

        [Fact]
        public void Update_TryUpdatePetWithInvalidPetDtoModelStateObjectAndValidId() {

            //Arrange
            mockDbContext.Setup(x => x.Pets.Find(1)).Returns(TestDataHelper.FakePetList().Find(p => p.Id == 1));
            var pet = new PetDto {
                Nome = "Neymar",
                Porte = "Junior",
                Personalidade = "",
                Adotado = false,
                Endereco = "rua teste",
                Imagem = "imagemdoneymarteste.com"
            };

            //Act
            var petDao = CreatePetDaoComEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => petDao.Update(pet, 1));
            Assert.Equal("Certifique-se de que todos os campos foram preenchidos corretamente", result.Message);
        }

        [Fact]
        public void Patch_PatchPet() {

            //Arrange
            mockDbContext.Setup(x => x.Pets.Find(1)).Returns(TestDataHelper.FakePetList().Find(p => p.Id == 1));
            var jsonPatchDocument = new JsonPatchDocument<PetDto>();

            //Act
            var petDao = CreatePetDaoComEfCoreObject();
            var result = petDao.UpdatePatch(1, jsonPatchDocument); ;

            Assert.True(result);
        }

        [Fact]
        public void Delete_DeletePetWithValidId() {

            //Arrange
            mockDbContext.Setup(x => x.Pets.Find(1)).Returns(TestDataHelper.FakePetList().Find(p => p.Id == 1));

            //Act
            var petDao = CreatePetDaoComEfCoreObject();
            var result = petDao.Delete(1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_TryDeletePetWithInvalidId() {

            //Arrange
            mockDbContext.Setup(x => x.Pets.Find(3)).Returns(TestDataHelper.FakePetList().Find(p => p.Id == 3));

            //Act
            var petDao = CreatePetDaoComEfCoreObject();

            //Assert
            var result = Assert.Throws<ArgumentException>(() => petDao.Delete(3));
            Assert.Equal("Pet Não Encontrado", result.Message);
        }

        public PetDaoComEfCore CreatePetDaoComEfCoreObject() {
            return new(mockDbContext.Object, new Mock<IMapper>().Object);
        }
    }
}