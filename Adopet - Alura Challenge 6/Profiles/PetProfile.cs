using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;

namespace Adopet___Alura_Challenge_6.Profiles {
    public class PetProfile : Profile{

        public PetProfile() {
            CreateMap<CreatePetDto, Pet>();
            CreateMap<Pet, ReadPetDto>();
        }
    }
}
