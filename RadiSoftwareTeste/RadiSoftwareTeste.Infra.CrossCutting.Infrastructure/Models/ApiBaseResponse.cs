using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadiSoftwareTeste.Infra.CrossCutting.Infrastructure.Models
{
    public class ApiBaseController : ControllerBase
    {
        protected BaseResponse<T> BaseResponse<T>(T data, bool success = true, string error = null)
        {
            return new BaseResponse<T>(data, success, error);
        }


    }
}
