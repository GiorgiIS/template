using ProjectTemplate.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Core.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            CreatedAt = DateTimeHelper.DateTimeNow();
            UpdatedAt = DateTimeHelper.DateTimeNow();
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
