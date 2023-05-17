using Adopet___Alura_Challenge_6.Data.Dtos.Tutor;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;

namespace Adopet___Alura_Challenge_6.Profiles {
    public class TutorProfile : Profile{

        public TutorProfile() {
            CreateMap<CreateTutorDto, Tutor>();
            CreateMap<UpdateTutorDto, Tutor>();
            CreateMap<Tutor, UpdateTutorDto>();
        }
    }
}
