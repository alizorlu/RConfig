using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pretech.Software.RConfig.ApiServer.Query.Config;

namespace Pretech.Software.RConfig.ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ConfigController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetIPAsync()
        //{
        //    var q = HttpContext.Connection.RemoteIpAddress.ToString();
        //    return Ok(q);
        //}
        [HttpGet("RawJson/{secret}")]
        public async Task<IActionResult> Raw([FromRoute] string secret)
        {
            var result = await _mediatr.Send(new QueryConfig() { Secret = secret, RequestIp = HttpContext.Connection.RemoteIpAddress.ToString() });

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else return BadRequest(result.Message);
        }
    }
}

