using ProjectTemplate.Repository.Interfaces;
using ProjectTemplate.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProjectTemplate.Core.Entities;
using System.Reflection;
using ProjectTemplate.Common;

namespace ProjectTemplate.Application
{
    public class TestService : CrudService<SomeTestEntity>, ITestService
    {
        public TestService(ITestRepository repository) : base(repository) { }
    }
}
