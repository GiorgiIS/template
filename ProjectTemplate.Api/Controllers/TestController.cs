using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Common.Api.RequestModels.Test;
using ProjectTemplate.Interfaces.Services;
using ProjectTemplate.Services.Dtos.SomeTestEntityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTemplate.Api.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public IActionResult Get(GetTestEntityRequestModel model)
        {
            var res = _testService.GetAll(model.Query);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Create(CreateTestEntityRequestModel model)
        {
            _testService.Create(model.TestEntityDto);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(DeleteTestEntityRequestModel model)
        {
            _testService.Delete(model.Id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UpdateTestEntityRequestModel model)
        {
            _testService.Update(model.SomeTestEntityUpdateDto);
            return Ok();
        }
    }
}
