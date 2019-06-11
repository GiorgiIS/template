using ProjectTemplate.Repository.Interfaces;
using ProjectTemplate.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Application
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public void TestMethod()
        {
            var result =_testRepository.GetAll();
        }
    }
}
