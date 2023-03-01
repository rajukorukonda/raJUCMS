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
    public class MedicalReportsController : ControllerBase
    {
        private readonly ILogger<MedicalReportsController> logger;
        private readonly IMedicalReportsRepository MedicalReportsRepository;
        public MedicalReportsController(ILogger<MedicalReportsController> _logger, IMedicalReportsRepository _MedicalReportsRepository)
        {
            MedicalReportsRepository = _MedicalReportsRepository;
            logger = _logger;
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<MedicalReports>> GetAllMedicalReports()
        {
            try
            {
                var result = await Task.FromResult(MedicalReportsRepository.GetAllMedicalReports());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        [EnableCors("CorsPolicy")]
        [HttpGet("{MedicalReportID}")]
        public async Task<ActionResult<MedicalReports>> GetMedicalReport(int MedicalReportID)
        {
            try
            {
                var result = await Task.FromResult(MedicalReportsRepository.GetMedicalReport(MedicalReportID));

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
        public async Task<ActionResult<MedicalReports>> AddMedicalReport(MedicalReports medicalReports)
        {
            try
            {

                var result = await Task.FromResult(MedicalReportsRepository.AddMedicalReport(medicalReports));
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
        public async Task<ActionResult<MedicalReports>> UpdateMedicalReport(MedicalReports medicalReports)
        {
            try
            {

                var result = await Task.FromResult(MedicalReportsRepository.UpdateMedicalReport(medicalReports));
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
        public async Task<ActionResult<MedicalReports>> DeleteMedicalReport(MedicalReports medicalReports)
        {
            try
            {
                var result = await Task.FromResult(MedicalReportsRepository.DeleteMedicalReport(medicalReports));
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
