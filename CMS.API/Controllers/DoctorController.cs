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
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> logger;
        private readonly IDoctorRepository DoctorRepository;

        public DoctorController(ILogger<DoctorController> _logger, IDoctorRepository _DoctorRepository)
        {
            DoctorRepository = _DoctorRepository;
            logger = _logger;
        }
        //[EnableCors("CorsPolicy")]
        //[HttpPost]
        //public async Task<ActionResult<Doctor>> CreateDoctor(Doctor doctor)
        //{
        //    try
        //    {


        //        var result = await Task.FromResult(DoctorRepository.AddDoctor(doctor));
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError($"Exception at Login Method: {ex}");
        //        return StatusCode(500, ex);
        //    }
        //}
        //[EnableCors("CorsPolicy")]
        //[HttpPost]
        //public async Task<ActionResult<Doctor>> CreateUpdateDoctor(Doctor doctor)
        //{
        //    try
        //    {
        //        var action = Request.Form["action"].ToString();
        //        Doctor doctor = new Doctor();
        //        if (action == "Update")
        //        {
        //            var doctorID = Convert.ToInt32(Request.Form["DoctorID"]);
        //            doctor.DoctorID = doctorID;
        //        }
        //        else
        //        {
        //            //  var serviceTypeID = DBNull.Value;
        //            doctor.DoctorID = 0;
        //        }
        //        doctor.Name = Request.Form["Name"].ToString();
        //        doctor.MobileNumber = Request.Form["MobileNumber"].ToString();
        //        doctor.DeptId = Convert.ToInt32(Request.Form["DeptId"].ToString());
        //        doctor.Experience = Request.Form["Experience"].ToString();
        //        doctor.GenderId = Convert.ToInt32(Request.Form["GenderId"].ToString());
        //        doctor.Qualification = Request.Form["Qualification"].ToString();
        //        doctor.Center = Request.Form["Center"].ToString();
        //        doctor.Email = Request.Form["Email"].ToString();
        //        doctor.Address = Request.Form["Address"].ToString();
        //        doctor.RoleId = Convert.ToInt32(Request.Form["RoleId"].ToString());
        //        doctor.Password = Request.Form["Password"].ToString();
        //        doctor.Action = action;

        //        var result = await Task.FromResult(DoctorRepository.AddUpdateDoctor(doctor));
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError($"Exception at Login Method: {ex}");
        //        return StatusCode(500, ex);
        //    }
        //}

        //[EnableCors("CorsPolicy")]
        //[HttpDelete]
        //public async Task<ActionResult<Doctor>> DeleteDoctor(int DoctorID)
        //{
        //    try
        //    {
        //        var result = await Task.FromResult(DoctorRepository.DeleteDoctor(DoctorID));
        //        logger.LogInformation("end");
        //        return Ok(result);

        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError($"Exception at Login Method: {ex}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //[EnableCors("CorsPolicy")]
        //[HttpGet]
        //public async Task<ActionResult<Doctors>> GetAllDoctors()
        //{
        //    try
        //    {
        //        var result = await Task.FromResult(DoctorRepository.GetAllDoctors());

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError($"Exception at Login Method: {ex}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
        [EnableCors("CorsPolicy")]
        [HttpGet("{DoctorID}")]
        public async Task<ActionResult<Doctors>> GetDoctor(int DoctorID)
        {
            try
            {
                var result = await Task.FromResult(DoctorRepository.GetDoctor(DoctorID));

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
        public async Task<ActionResult<Doctors>> GetAllDoctors()
        {
            try
            {
                var result = await Task.FromResult(DoctorRepository.GetAllDoctors());

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
