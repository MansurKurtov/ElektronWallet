using EWalletService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Root.Models;
using Serilog;
using System;
using System.Threading.Tasks;

namespace EWallentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EWallentApiController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IElectronWalletService _electronWalletService;

        public EWallentApiController(ILogger logger, IElectronWalletService electronWalletService)
        {
            _electronWalletService = electronWalletService;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Digest")]
        public async Task<ResponseData> IsAccountAxists(string accountNumber)
        {
            try
            {
                var result = await _electronWalletService.IsAccountAxists(accountNumber);
                return new ResponseData(ResponseStatus.Ok, result);
            }
            catch(Exception ex)
            {
                _logger.Error("Ошибка в методе modules:" + ex.Message);
                _logger.Information("Подробная информация об ошибке: " + ex.InnerException);
                return new ResponseData(ResponseStatus.InternalServerError, ex.Message);
            }
        }
    }
}
