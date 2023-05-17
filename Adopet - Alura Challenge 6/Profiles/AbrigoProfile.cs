using Adopet___Alura_Challenge_6.Data.Dtos.Abrigo;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;

namespace Adopet___Alura_Challenge_6.Profiles {
    public class AbrigoProfile : Profile{

        public AbrigoProfile() {
            CreateMap<Abrigo, ReadAbrigoDto>();
            CreateMap<CreateAbrigoDto, Abrigo>();
            CreateMap<UpdateAbrigoDto, Abrigo>();
            CreateMap<Abrigo, UpdateAbrigoDto > ();
        }
    }
}
