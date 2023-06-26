using Adopet___Alura_Challenge_6.Models;

namespace Adopet.Tests.Helper {
    static class TestDataHelper {

        public static List<Abrigo> FakeAbrigoList() {
            return new List<Abrigo> {
                new Abrigo {
                    Id = 1,
                    Logradouro = "rua teste1",
                    Numero = 123,
                    Estado = "estado teste1",
                    Pets = {}
                },
                new Abrigo {
                    Id = 2,
                    Logradouro = "rua teste2",
                    Numero = 321,
                    Estado = "estado teste2",
                    Pets = {}
                }
            };
        }

        public static List<Adocao> FakeAdocaoList() {
            return new List<Adocao> {
                new Adocao {
                    Id = 1,
                    PetId = 1,
                    Pet = { },
                    TutorId = 1,
                    Tutor = { },
                    Time = DateTime.Now
                },
                new Adocao {
                    Id = 2,
                    PetId = 2,
                    Pet = { },
                    TutorId = 2,
                    Tutor = { },
                    Time = DateTime.Now
                }
            };
        }

        public static List<Pet> FakePetList() {
            return new List<Pet> {
                new Pet {
                    Id = 1,
                    AbrigoId = 1,
                    Nome = "José",
                    Idade = 3,
                    Porte = "Médio",
                    Personalidade = "Agitado",
                    Adotado = false,
                    Endereco = "rua teste 1",
                    Imagem = "https://imagemtestefalsa.com.br",
                    Abrigo = { },
                    Adocao = { }
                },
                new Pet {
                    Id = 2,
                    AbrigoId = 2,
                    Nome = "Ronaldo",
                    Idade = 5,
                    Porte = "Grande",
                    Personalidade = "Brincalhão",
                    Adotado = false,
                    Endereco = "rua teste 2",
                    Imagem = "https://imagemtestefalsa.com.br",
                    Abrigo = { },
                    Adocao = { }
                },
            };
        }

        public static List<Tutor> FakeTutorList() {
            return new List<Tutor> {
                new Tutor {
                    Id = 1,
                    Nome = "Gustavo",
                    Email = "gustavo.teste@teste.com",
                    Adocao = { }
                },
                new Tutor {
                    Id = 2,
                    Nome = "Fernando",
                    Email = "fernando.teste@teste.com",
                    Adocao = { }
                }
            };
        }
    }
}