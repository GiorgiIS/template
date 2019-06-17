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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTemplate.Api.Controllers
{
    [Route("Api/Test")]
    [ApiController]
    public class TestController : CrudController<SomeTestEntity, TestEntityDto, BaseSearchQuery,  ITestService>
    {
        public TestController(ITestService service, IMapper mapper) : base(service, mapper) { }

        public override string Create([FromBody, Required] TestEntityDto dto)
        {
            return base.Create(dto);
        }

        public override TestEntityDto Get([FromRoute] string id)
        {
            return base.Get(id);
        }

        public override IEnumerable<TestEntityDto> GetList([FromQuery] BaseSearchQuery query)
        {
            return base.GetList(query);
        }

        public override void Update([FromBody] TestEntityDto dto)
        {
            base.Update(dto);
        }

        public override void Delete([FromRoute] string id)
        {
            base.Delete(id);
        }
    }
}
