using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Services.Dtos
{
    public abstract class DtoBase<TEntity> where TEntity : EntityBase
    {
        public abstract TEntity Projection();
    }
}
