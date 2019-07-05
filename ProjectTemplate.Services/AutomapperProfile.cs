using AutoMapper;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Services.Dtos.TestEntityDtos;

namespace ProjectTemplate.Services
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<SomeTestEntity, SomeTestEntityReadDto>().ReverseMap();
            CreateMap<SomeTestEntity, SomeTestEntityCreateDto>().ReverseMap();
            CreateMap<SomeTestEntity, SomeTestEntityUpdateDto>().ReverseMap();
        }
    }
}
