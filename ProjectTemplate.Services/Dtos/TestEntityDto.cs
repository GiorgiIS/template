using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Services.Dtos.SomeTestEntityDtos
{
    public class TestEntityDto : DtoBase<SomeTestEntity>
    {
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public int SomeIntValue { get; set; }
        public string SomeStringValue { get; set; }
        public DateTime SomeDateTimeValue { get; set; }

        public override SomeTestEntity Projection()
        {
            var entity = new SomeTestEntity()
            {
                SomeIntValue = SomeIntValue,
                SomeStringValue = SomeStringValue,
                SomeDateTimeValue = SomeDateTimeValue
            };

            return entity;
        }
    }
}
