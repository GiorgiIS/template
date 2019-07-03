using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Services.Dtos.TestEntityDtos
{
    public class SomeTestEntityCreateDto : CreateDtoBase<SomeTestEntity>
    {
        public int SomeIntValue { get; set; }
        public string SomeStringValue { get; set; }
        public DateTime SomeDateTimeValue { get; set; }
    }
}
