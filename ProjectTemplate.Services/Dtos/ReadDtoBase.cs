using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Services.Dtos
{
    public abstract class ReadDtoBase<TEntity> where TEntity : EntityBase
    {
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
