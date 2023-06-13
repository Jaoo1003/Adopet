using AdopetUsuario.Data.Dtos;
using AdopetUsuario.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AdopetUsuario.Profiles {
    public class UsuarioProfile : Profile{
        public UsuarioProfile() {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
