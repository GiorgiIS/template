using System;

namespace ProjectTemplate.Common.Api.RequestModels
{
    public class SomeTestEntitySearchQuery : BaseSearchQuery
    {
        public int SomeIntValue { get; set; }
		public string SomestringValue { get; set; }
		public DateTime SomeDateTimeValueFrom { get; set; }
		public DateTime SomeDateTimeValueTo { get; set; }
    }
}
