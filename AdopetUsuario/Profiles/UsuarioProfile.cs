using AdopetUsuario.Data.Dtos;
using AdopetUsuario.Models;
using AutoMapper;

namespace AdopetUsuario.Profiles {
    public class UsuarioProfile : Profile{
        public UsuarioProfile() {
            CreateMap<CreateUsuarioDto, User>();
        }
    }
}
