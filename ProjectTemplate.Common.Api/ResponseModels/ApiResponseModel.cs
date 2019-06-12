using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Common.Api.ResponseModels
{
    public class ApiResponseModel<T>
    {
        protected ApiResponseModel()
        {
            Errors = new List<string>();
        }

        public int Status { get; set; }
        public string Description { get; set; }
        public List<string> Errors { get; }

        public T ResponseObject { get; set; }

        public static ApiResponseModel<T> Ok(T responseObject)
        {
            var model = new ApiResponseModel<T>
            {
                Status = 0,
                ResponseObject = responseObject
            };

            return model;
        }

        public static ApiResponseModel<T> Fail(List<string> errors)
        {
            var model = new ApiResponseModel<T>
            {
                Status = -1,
            };

            model.Errors.AddRange(errors);

            return model;
        }
    }
}