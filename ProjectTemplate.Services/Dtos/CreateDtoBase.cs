using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Services.Dtos.TestEntityDtos
{
    public abstract class CreateDtoBase<TEntity> where TEntity : EntityBase
    {
        public abstract TEntity Projection();
    }
}
