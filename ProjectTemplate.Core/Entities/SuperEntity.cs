using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Core.Entities
{
    public class SuperEntity : EntityBase
    {
        public int? SomeIntValue { get; set; }
        public string SomeStringValue { get; set; }
        public bool SomeBoolValueAlso { get; set; }
        public double SomeDoubleValue { get; set; }
        public float SomeFloatValue { get; set; }
        public long SomeLongValue { get; set; }
        public decimal? SomeDecimalValue { get; set; }
        public DateTime SomeDateTime { get; set; }
        public DateTime? SomeNullableDateTime { get; set; }
    }
}