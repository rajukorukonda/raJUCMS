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
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> logger;
        private readonly IRegistrationRepository RegistrationRepository;
        public RegistrationController(ILogger<RegistrationController> _logger, IRegistrationRepository _RegistrationRepository)
        {
            RegistrationRepository = _RegistrationRepository;
            logger = _logger;
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<Registration>> GetAllUsers()
        {
            try
            {
                var result = await Task.FromResult(RegistrationRepository.GetAllUsers());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{RegistrationID}")]
        public async Task<ActionResult<Registration>> GetUser(int RegistrationID)
        {
            try
            {
                var result = await Task.FromResult(RegistrationRepository.GetUser(RegistrationID));

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpPost]
        public async Task<ActionResult<Registration>> AddUser(Registration registration)
        {
            try
            {

                var result = await Task.FromResult(RegistrationRepository.AddUser(registration));
                logger.LogInformation("end");
                return Ok(result);

            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpPut]
        public async Task<ActionResult<Registration>> UpdateUser(Registration registration)
        {
            try
            {

                var result = await Task.FromResult(RegistrationRepository.UpdateUser(registration));
                logger.LogInformation("end");
                return Ok(result);

            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpDelete]
        public async Task<ActionResult<Registration>> DeleteUser(Registration registration)
        {
            try
            {
                var result = await Task.FromResult(RegistrationRepository.DeleteUser(registration));
                logger.LogInformation("end");
                return Ok(result);

            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
