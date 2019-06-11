using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Services.Dtos.SomeTestEntityDtos
{
    public class TestSearchQuery : BaseSearchQuery
    {
        public int? SomeIntValue { get; set; }
        public string SomeStringValue { get; set; }
        public DateTime? SomeDateTimeValueFrom { get; set; }
        public DateTime? SomeDateTimeValueTo { get; set; }
    }
}
