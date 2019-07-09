using AutoMapper;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Services.Dtos.SomeTestEntityDtos;

namespace ProjectTemplate.Services
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<SomeTestEntity, SomeTestEntityCreateDto>().ReverseMap();
			CreateMap<SomeTestEntity, SomeTestEntityUpdateDto>().ReverseMap();
			CreateMap<SomeTestEntity, SomeTestEntityReadDto>().ReverseMap();
        }
    }
}
