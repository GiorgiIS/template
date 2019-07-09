using ProjectTemplate.Core.Entities;
using System;

namespace ProjectTemplate.Services.Dtos.SomeTestEntityDtos
{
    public class SomeTestEntityReadDto : ReadDtoBase<SomeTestEntity>
    {
       public int SomeIntValue { get; set; }
		public string SomestringValue { get; set; }
		public DateTime SomeDateTimeValue { get; set; }
    }
}
