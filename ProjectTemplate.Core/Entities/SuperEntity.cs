using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Core.Entities
{
    public class SuperEntity : EntityBase
    {
        public int SomeIntValue { get; set; }
        public string SomeStringValue { get; set; }
        public bool SomeBoolValueAlso { get; set; }
    }
}