using Adopet___Alura_Challenge_6.Data.Dtos.Adocoes;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;

namespace Adopet___Alura_Challenge_6.Profiles {
    public class AdocaoProfile : Profile{
        public AdocaoProfile() {
            CreateMap<CreateAdocaoDto, Adocao>();
            CreateMap<Adocao, ReadAdocaoDto>();
        }
    }
}
