using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Root.Models;

namespace EWallentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EWallentApiController : ControllerBase
    {
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Digest")]
        public ResponseData IsAccountAxists(string accountNumber)
        {

        }
    }
}
