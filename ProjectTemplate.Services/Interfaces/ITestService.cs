using ProjectTemplate.Services.Dtos.SomeTestEntityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTemplate.Interfaces.Services
{
    public interface ITestService
    {
        IQueryable<object> GetAll();
        IQueryable<object> GetById(string id);
        object Create(SomeTestEntityCreateDto entity);
        void Update(SomeTestEntityUpdateDto entity);
        void Delete(string id);
    }
}