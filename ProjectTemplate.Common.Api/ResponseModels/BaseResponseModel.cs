using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Common.Api.ResponseModels
{
    public class BaseResponseModel<T>
    {
        public BaseResponseModel()
        {
            Errors = new List<string>();
        }

        public int Status { get; set; }
        public string Description { get; set; }
        public List<string> Errors{ get; }

        public T ResponseObject { get; set; }
    }
}
