using AutoMapper;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Services.Dtos.SomeTestEntityDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SomeTestEntity, TestEntityDto>().ReverseMap();
        }
    }
}
