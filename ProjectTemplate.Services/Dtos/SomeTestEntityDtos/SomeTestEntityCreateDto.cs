using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Services.Dtos.SomeTestEntityDtos
{
    public class SomeTestEntityCreateDto
    {
        public int SomeIntValue { get; set; }
        public string SomeStringValue { get; set; }
        public DateTime SomeDateTimeValue { get; set; }

        public SomeTestEntity Projection()
        {
            var instance = new SomeTestEntity()
            {
                SomeDateTimeValue = SomeDateTimeValue,
                SomeIntValue = SomeIntValue,
                SomeStringValue = SomeStringValue
            };

            return instance;
        }
    }
}
