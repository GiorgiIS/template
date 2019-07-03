using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Common.Api;
using ProjectTemplate.Common.Api.RequestModels;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Interfaces.Services;
using ProjectTemplate.Services.Dtos.TestEntityDtos;

namespace ProjectTemplate.Api.Controllers
{
    [Route("Api/Test")]
    [ApiController]
    public class TestController : CrudController<SomeTestEntity, SomeTestEntityReadDto, SomeTestEntityCreateDto, SomeTestEntityUpdateDto, TestSearchQuery,  ITestService>
    {
        public TestController(ITestService service, IMapper mapper) : base(service, mapper) { }
    }
}
