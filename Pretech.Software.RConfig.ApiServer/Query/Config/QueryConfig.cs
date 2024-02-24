using MediatR;
using Pretech.Software.RConfig.ApiServer.Response;
using System.ComponentModel.DataAnnotations;

namespace Pretech.Software.RConfig.ApiServer.Query.Config
{
    public class QueryConfig : IRequest<ResponseBase<ResponseConfig>>
    {
        [Required]
        public string Secret { get; set; }
        [Required]
        public string RequestIp { get; set; }
    }
}
