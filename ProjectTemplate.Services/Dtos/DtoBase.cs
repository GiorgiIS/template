using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Services.Dtos
{
    public interface IDtoBase<TEntity> where TEntity : EntityBase
    {
        TEntity Projection();
    }
}
