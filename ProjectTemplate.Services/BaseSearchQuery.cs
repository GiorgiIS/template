using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Services
{
    public class BaseSearchQuery
    {
        public string Id { get; set; }
        public DateTime? CreatedAtFrom { get; set; }
        public DateTime? CreatedAtTo { get; set; }
        public DateTime? UpdatedAtFrom { get; set; }
        public DateTime? UpdatedAtTo { get; set; }
        public DateTime? DeletedAtFrom { get; set; }
        public DateTime? DeletedAtTo { get; set; }
    }
}
