using ProjectTemplate.Core.Entities;
using ProjectTemplate.Repository.EF;
using ProjectTemplate.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Repository.Implementations
{
    public class TestRepository : RepositoryBase<SomeTestEntity>, ITestRepository
    {
        public TestRepository(CustomDbContext context) : base(context) { }
    }
}
