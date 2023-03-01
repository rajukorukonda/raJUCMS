using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CMS.Models;
using CMS.Repository;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Cors;

namespace CMS.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        private readonly IUtilitiesRepository utilitiesRepository;
        private readonly ILogger<UtilitiesController> logger;
        public UtilitiesController(IUtilitiesRepository _utilitiesRepository, ILogger<UtilitiesController> _logger)
        {
            utilitiesRepository = _utilitiesRepository;
            logger = _logger;
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<AppointmentBill>> GetAllAppointmentBills()
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetAllAppointmentBills());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{PriceID}")]
        public async Task<ActionResult<AppointmentBill>> GetAppointmentBill(int PriceID)
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetAppointmentBill(PriceID));

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<State>> GetAllStates()
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetAllStates());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{StateID}")]
        public async Task<ActionResult<State>> GetState(int StateID)
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetState(StateID));

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<Services>> GetServices()
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetServices());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{ServiceID}")]
        public async Task<ActionResult<Services>> GetService(int ServiceID)
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetService(ServiceID));

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<Slots>> GetSlots()
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetSlots());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{SlotID}")]
        public async Task<ActionResult<Slots>> GetSlot(int SlotID)
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetSlot(SlotID));

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<Genders>> GetAllGenders()
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetAllGenders());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{GenderID}")]
        public async Task<ActionResult<Genders>> GetGender(int GenderID)
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetGender(GenderID));

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<MOP>> GetAllMOP()
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetAllMOP());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{ModeofPaymentID}")]
        public async Task<ActionResult<MOP>> GetMOP(int ModeofPaymentID)
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetMOP(ModeofPaymentID));

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<Status>> GetStatuses()
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetStatuses());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{StatusId}")]
        public async Task<ActionResult<Status>> GetStatus(int StatusID)
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetStatus(StatusID));

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<Roles>> GetAllRoles()
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetAllRoles());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{RoleID}")]
        public async Task<ActionResult<Roles>> GetRole(int RoleID)
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetRole(RoleID));

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<Specialization>> GetAllSpecializations()
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetAllSpecializations());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{SpecializationID}")]
        public async Task<ActionResult<Specialization>> GetSpecialization(int SpecializationID)
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetSpecialization(SpecializationID));

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<TypeofReports>> GetAllTypeofReports()
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetAllTypeofReports());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{TypeofReportID}")]
        public async Task<ActionResult<TypeofReports>> GetTypeofReport(int TypeofReportID)
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetTypeofReport(TypeofReportID));

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<Discounts>> GetAllDiscounts()
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetAllDiscounts());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{DiscountID}")]
        public async Task<ActionResult<Discounts>> GetDiscount(int DiscountID)
        {
            try
            {
                var result = await Task.FromResult(utilitiesRepository.GetDiscount(DiscountID));

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
