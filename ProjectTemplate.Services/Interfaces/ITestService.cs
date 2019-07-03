using ProjectTemplate.Core.Entities;
using ProjectTemplate.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTemplate.Interfaces.Services
{
    public interface ITestService : ICrudService<SomeTestEntity>
    {
    }
}