﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Core.Entities
{
    public class SomeTestEntity : BaseEntity
    {
        public int SomeIntValue { get; set; }
        public string SomeStringValue { get; set; }
        public DateTime SomeDateTimeValue { get; set; }
    }
}