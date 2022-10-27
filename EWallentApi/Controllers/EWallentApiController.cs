using EWalletService.Models;
using EWalletService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Root.Models;
using Serilog;
using System;
using System.Threading.Tasks;

namespace EWallentApi.Controllers
{
    /// <summary>
    /// В этом проекте я использовал GitHub проект DigestAuthentication для реализации Digest auth,
    /// Для логирования я использовал Serilog и Autofac для автоматической регистрации/injection сервисов
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EWallentApiController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IElectronWalletService _electronWalletService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="electronWalletService"></param>
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
                var result = await _electronWalletService.IsAccountAxistsAsync(accountNumber);
                return new ResponseData(ResponseStatus.Ok, result);
            }
            catch(Exception ex)
            {
                _logger.Error("Ошибка в методе IsAccountAxists:" + ex.Message);
                _logger.Information("Подробная информация об ошибке: " + ex.StackTrace);
                return new ResponseData(ResponseStatus.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Digest")]
        public async Task<ResponseData> ReplenishAccount([FromBody] ReplenishPostModel data)
        {
            try
            {
                return await _electronWalletService.ReplenishAccountAsync(data);
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка в методе ReplenishAccount:" + ex.Message);
                _logger.Information("Подробная информация об ошибке: " + ex.StackTrace);
                return new ResponseData(ResponseStatus.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Digest")]
        public async Task<ResponseData> GetAccountHistoryForCurrentMonth(string accountNumber)
        {
            try
            {
                return await _electronWalletService.GetAccountHistoryForCurrentMonthAsync(accountNumber);
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка в методе GetAccountHistoryForCurrentMonth:" + ex.Message);
                _logger.Information("Подробная информация об ошибке: " + ex.StackTrace);
                return new ResponseData(ResponseStatus.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Digest")]
        public async Task<ResponseData> GetBalance(string accountNumber)
        {
            try
            {
                return await _electronWalletService.GetBalanceAsync(accountNumber);
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка в методе GetBalance:" + ex.Message);
                _logger.Information("Подробная информация об ошибке: " + ex.StackTrace);
                return new ResponseData(ResponseStatus.InternalServerError, ex.Message);
            }

        }

    }
}
