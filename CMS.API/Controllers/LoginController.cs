using CMS.Models;
using CMS.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository loginRepository;
        private readonly ILogger<LoginController> logger;
        public LoginController(ILoginRepository _loginRepository, ILogger<LoginController> _logger)
        {
            loginRepository = _loginRepository;
            logger = _logger;
        }
       // [EnableCors("CorsPolicy")]
        [HttpPost]
        public async Task<ActionResult<Login>> UserExist(Login login)
        {
            try
            {
                var result = await Task.FromResult(loginRepository.CheckUserExist(login));
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
               // Console.WriteLine($"Exception at Login Method: {ex}");
                return StatusCode(500, ex.Message+ex.Source + ex.InnerException+ex.StackTrace);
            }
        }
    }
}
