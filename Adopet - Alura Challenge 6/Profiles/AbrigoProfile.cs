﻿using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;

namespace Adopet___Alura_Challenge_6.Profiles {
    public class AbrigoProfile : Profile{

        public AbrigoProfile() {
            CreateMap<AbrigoDto, Abrigo>();
        }
    }
}
