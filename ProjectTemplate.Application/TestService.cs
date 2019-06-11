using ProjectTemplate.Repository.Interfaces;
using ProjectTemplate.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProjectTemplate.Services.Dtos.SomeTestEntityDtos;

namespace ProjectTemplate.Application
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public void Create(SomeTestEntityCreateDto dto)
        {
            var entity = dto.Projection();
            _testRepository.Create(entity);
            var count = _testRepository.SaveChanges();
        }

        public void Delete(string id)
        {
         _testRepository.Delete(id);
            var count = _testRepository.SaveChanges();

        }

        public IQueryable<object> GetAll()
        {
            var result =_testRepository.GetAll();
            return result;
        }

        public IQueryable<object> GetById(string id)
        {
            var result = _testRepository.Get(c => c.Id == id);
            return result;
        }

        public void Update(SomeTestEntityUpdateDto dto)
        {
            var entity = dto.Projection();
            _testRepository.Update(entity);
            var count = _testRepository.SaveChanges();
        }
    }
}
