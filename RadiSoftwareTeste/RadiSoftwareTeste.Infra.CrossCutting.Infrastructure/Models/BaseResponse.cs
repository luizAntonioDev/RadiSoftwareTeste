using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadiSoftwareTeste.Infra.CrossCutting.Infrastructure.Models
{
    public class BaseResponse<T> : IActionResult
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }

        public T Data { get; set; }


        public BaseResponse(T data, bool success, string error)
        {
            Errors = new List<string>();
            Data = data;
            IsSuccess = success;
            if (error != null)
            {
                Errors.Add(error);
            }
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
