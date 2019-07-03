using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Services.Dtos.SomeTestEntityDtos
{
    public class TestEntityDto : IDtoBase<SomeTestEntity>
    {
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public int SomeIntValue { get; set; }
        public string SomeStringValue { get; set; }
        public DateTime SomeDateTimeValue { get; set; }

        public SomeTestEntity FullProjection()
        {
            var entity = new SomeTestEntity()
            {
                SomeIntValue = SomeIntValue,
                SomeStringValue = SomeStringValue,
                SomeDateTimeValue = SomeDateTimeValue,
                Id = Id
            };

            return entity;
        }

        public SomeTestEntity PartProjection()
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
