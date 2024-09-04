using Microsoft.AspNetCore.Mvc;
using NLog;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly Logger _logger = LogManager.GetCurrentClassLogger();

        protected ActionResult<BaseResponseModel> GenerateJson<T>(int status, string message, T body)
        {
            
                BaseResponseModel response = new BaseResponseModel()
                {
                    Status = status,
                    Message = message,
                    Body = body
                };
                return Ok(response);
        }

        protected ActionResult<BaseResponseModel> GenerateJson(int status, string message)
        {
            BaseResponseModel response = new BaseResponseModel()
            {
                Status = status,
                Message = message
            };
            return Ok(response);
        }
    }
}
