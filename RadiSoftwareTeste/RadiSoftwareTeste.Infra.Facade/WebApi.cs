using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RadiSoftwareTeste.Infra.CrossCutting.Infrastructure.Models;
using RadiSoftwareTeste.Infra.Facade.Enums;
using System.Net;
using System.Text;

namespace RadiSoftwareTeste.Infra.Facade
{

    public static class WebApi
    {
        public static string Client(string path, MethodTypeEnum method, IConfiguration _configuration, string project, object payload = null)
        {
            using (var client = new WebClient())
            {
                client.BaseAddress = _configuration.GetSection(project).GetSection("Url").Value;
                client.Encoding = Encoding.UTF8;
                client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";

                switch (method)
                {
                    case MethodTypeEnum.GET:
                        return client.DownloadString(path);
                    case MethodTypeEnum.POST:
                        string postJson = JsonConvert.SerializeObject(payload);
                        return client.UploadString(path, "POST", postJson);
                    default:
                        return null;
                }
            }
        }

        public static T GetResponse<T>(string response)
        {
            var baseResponse = JsonConvert.DeserializeObject<BaseResponse<T>>(response);
            return baseResponse.Data;
        }
    }
}
