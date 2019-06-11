using ProjectTemplate.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Core.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = CustomDateTime.Now();
            UpdatedAt = CustomDateTime.Now();
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
