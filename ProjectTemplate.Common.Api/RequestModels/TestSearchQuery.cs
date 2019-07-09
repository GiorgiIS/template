using System;

namespace ProjectTemplate.Common.Api.RequestModels
{
    public class TestSearchQuery : BaseSearchQuery
    {
        public int? SomeIntValue { get; set; }
        public string SomeStringValue { get; set; }
        public DateTime? SomeDateTimeValueFrom { get; set; }
        public DateTime? SomeDateTimeValueTo { get; set; }
    }
}
