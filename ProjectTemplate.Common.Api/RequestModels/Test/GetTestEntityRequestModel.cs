using ProjectTemplate.Services.Dtos.SomeTestEntityDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Common.Api.RequestModels.Test
{
    public class GetTestEntityRequestModel
    {
        public TestSearchQuery Query { get; set; }
    }
}
