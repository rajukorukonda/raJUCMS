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
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> logger;
        private readonly IPatientsRepository PatientsRepository;
        public PatientsController(ILogger<PatientsController> _logger, IPatientsRepository _PatientsRepository)
        {
            PatientsRepository = _PatientsRepository;
            logger = _logger;
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<Patients>> GetAllPatients()
        {
            try
            {
                var result = await Task.FromResult(PatientsRepository.GetAllPatients());

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [EnableCors("CorsPolicy")]
        [HttpGet("{PatientID}")]
        public async Task<ActionResult<Patients>> GetPatient(int PatientID)
        {
            try
            {
                var result = await Task.FromResult(PatientsRepository.GetPatient(PatientID));

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
        public async Task<ActionResult<Patients>> AddUpdatePatient()
        {
            try
            {
                var action = Request.Form["action"].ToString();
                Patients patients = new Patients();
                if (action == "Update")
                {
                    var patientID = Convert.ToInt32(Request.Form["patientID"]);
                    patients.PatientID = patientID;
                }
                else
                {

                    patients.PatientID = 0;
                }
                patients.PatientName = Request.Form["PatientName"].ToString();
                patients.PatientLastName = Request.Form["PatientLastName"].ToString();
                patients.Mobile = Request.Form["Mobile"].ToString();
                patients.Email = Request.Form["Email"].ToString();
                patients.Address = Request.Form["Address"].ToString();
                patients.StateID = Convert.ToInt32(Request.Form["StateID"]);
                patients.City = Request.Form["City"].ToString();
                patients.Pincode = Request.Form["Pincode"].ToString();
                patients.DOB = Request.Form["DOB"].ToString();
                patients.Age = Convert.ToInt32(Request.Form["Age"]);
                patients.GenderID = Convert.ToInt32(Request.Form["GenderID"]);
                patients.RoleID = Convert.ToInt32(Request.Form["RoleID"]);
                patients.ReferBy = Request.Form["ReferBy"].ToString();
                patients.Action = action;
                var result = await Task.FromResult(PatientsRepository.AddUpdatePatient(patients));
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
        [HttpPost]
        public async Task<ActionResult<RegisterPatientAppointment>> AddRegisterPatientAppointment(RegisterPatientAppointment registerPatientAppointment)
        {
            try
            {

                var result = await Task.FromResult(PatientsRepository.AddRegisterPatientAppointment(registerPatientAppointment));
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
        public async Task<ActionResult<Patients>> DeletePatient(Patients patients)
        {
            try
            {
                var result = await Task.FromResult(PatientsRepository.DeletePatient(patients));
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
