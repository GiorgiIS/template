using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            var res = _testService.GetAll();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Create(SomeTestEntityCreateDto dto)
        {
            _testService.Create(dto);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            _testService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(SomeTestEntityUpdateDto dto)
        {
            _testService.Update(dto);
            return Ok();
        }
    }
}
