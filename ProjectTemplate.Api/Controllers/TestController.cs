using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Common;
using ProjectTemplate.Common.Api;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Interfaces.Services;
using ProjectTemplate.Repository.Implementations;
using ProjectTemplate.Repository.Interfaces;
using ProjectTemplate.Services.Dtos.SomeTestEntityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTemplate.Api.Controllers
{
    [Route("Api/Test")]
    public class TestController : CrudController<SomeTestEntity, TestEntityDto, BaseSearchQuery, ITestRepository>
    {
        public TestController(ITestRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
