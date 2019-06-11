using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Services;
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
            _testService.TestMethod();
            return Ok();
        }
    }
}
