using CMS.Models;
using CMS.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CMS.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientsAppointmentsController : ControllerBase
    {
        private readonly ILogger<PatientsAppointmentsController> logger;
        private readonly IPatientsAppointmentsRepository PatientsAppointmentsRepository;
        public readonly XmlProviders xml;
        private static readonly HttpClient client = new HttpClient();
        public PatientsAppointmentsController(ILogger<PatientsAppointmentsController> _logger, IPatientsAppointmentsRepository _PatientsAppointmentsRepository)
        {
            PatientsAppointmentsRepository = _PatientsAppointmentsRepository;
            logger = _logger;
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<AppointmentDetails>> GetAllAppointments()
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.GetAllAppointments());

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
        public async Task<ActionResult<AppointmentDetails>> GetAllAppointments_Distict()
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.GetAllAppointments_Distict());

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
        public async Task<ActionResult<AppointmentDetails>> GetReportPatientList(ReportList reportList)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.GetReportPatientList(reportList));

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
        public async Task<ActionResult<MedicineList>> GetMedicineList()
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.GetMedicineList());

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
        public async Task<ActionResult<MedicineList>> AddUpdateMedicine(List<MedicineList> medicineList)
        {
            try
            {

                var result = await Task.FromResult(PatientsAppointmentsRepository.AddUpdateMedicine(medicineList));
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
        [HttpGet("{AppointmentID}")]
        public async Task<ActionResult<AppointmentDetails>> GetAppointment(int AppointmentID)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.GetAppointment(AppointmentID));

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
        public async Task<ActionResult<PatientsAppointments>> AddUpdateAppointment(PatientsAppointments patientsAppointments)
        {
            try
            {

                var result = await Task.FromResult(PatientsAppointmentsRepository.AddUpdateAppointment(patientsAppointments));
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
        public async Task<ActionResult<PatientsAppointments>> DeleteAppointment(PatientsAppointments patientsAppointments)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.DeleteAppointment(patientsAppointments));
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
        public async Task<ActionResult<Docs>> VitalsCRUD([FromBody] List<Vitals> vitals)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.VitalsCRUD(vitals as List<Vitals>));
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
        public async Task<ActionResult<Docs>> DocsCrud([FromBody] List<Docs> docs)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.DocsCrud(docs as List<Docs>));
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
        public async Task<ActionResult<VisitReason>> VisitReason_Crud([FromBody] List<VisitReason> visitReason)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.VisitReason_Crud(visitReason as List<VisitReason>));
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
        public async Task<ActionResult<PatientHistory>> PatientHistory([FromBody] List<PatientHistory> visitReason)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.PatientHistory(visitReason as List<PatientHistory>));
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
        public async Task<ActionResult<Complaints>> ComplaintsCrud([FromBody] List<Complaints> complaints)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.ComplaintsCrud(complaints as List<Complaints>));
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
        public async Task<ActionResult<ComplaintsList>> GetComplaintsXML(ComplaintsList complaintsList)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.GetComplaintsXML(complaintsList));
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
        public async Task<ActionResult<VitalDocs>> GetDocumentsXML(VitalDocs vitalDocs)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.GetDocumentsXML(vitalDocs));
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
        public async Task<ActionResult<VitalDocs>> GetMedicineXML(MedicationList medicationList)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.GetMedicineXML(medicationList));
                logger.LogInformation("end");
                return Ok(result);

            }
            catch (Exception ex)
            {
                logger.LogError($"Exception at Login Method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }




        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("VitalsDocs");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [EnableCors("CorsPolicy")]
        [HttpPost]
        public async Task<ActionResult<Registeration>> RegisterationCRUD([FromBody] List<Registeration> registeration)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.RegisterationCRUD(registeration as List<Registeration>));
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
        public async Task<ActionResult<DoctorsAvailability>> DoctorsAvailability([FromBody] List<DoctorsAvailability> docsAvail)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.DoctorsAvailability(docsAvail as List<DoctorsAvailability>));
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
        public async Task<ActionResult<DoctorsAvailabilitySlots>> DoctorsAvailabilitySlots([FromBody] List<DoctorsAvailability> docs)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.DoctorsAvailabilitySlots(docs as List<DoctorsAvailability>));
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
        public async Task<ActionResult<DoctorsAvailabilitySlots>> GetAvailabilityXML([FromBody] List<DoctorsAvailability> docs)
        {
            try
            {
                var result = await Task.FromResult(PatientsAppointmentsRepository.GetAvailabilityXML(docs as List<DoctorsAvailability>));
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
