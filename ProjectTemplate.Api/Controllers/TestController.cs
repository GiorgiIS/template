using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Common.Api;
using ProjectTemplate.Common.Api.RequestModels;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Interfaces.Services;
using ProjectTemplate.Services.Dtos.SomeTestEntityDtos;

namespace ProjectTemplate.Api.Controllers
{
    [Route("Api/Test")]
    [ApiController]
    public class TestController : CrudController<SomeTestEntity, TestEntityDto, TestSearchQuery,  ITestService>
    {
        public TestController(ITestService service, IMapper mapper) : base(service, mapper) { }
    }
}
