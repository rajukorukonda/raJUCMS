using CMS.Models;
using CMS.Service;
using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Cors;

namespace CMS.Repository
{
    [EnableCors("CorsPolicy")]
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IDapper dapper;
        public RegistrationRepository(IDapper _dapper)
        {
            dapper = _dapper;
        }
        public Registration GetUser(int RegistrationID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("RegistrationID", RegistrationID, DbType.Int32);
            var result = dapper.Get<Registration>("[dbo].[SP_Get_Registration]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<Registration> GetAllUsers()
        {
            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<Registration>("[dbo].[SP_Get_AllRegistration]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public int AddUser(Registration registration)
        {
            var dbParam = new DynamicParameters();

            dbParam.Add("RegistrationID", registration.RegistrationID, DbType.Int32);
            dbParam.Add("RoleID", registration.RoleID, DbType.Int32);
            dbParam.Add("Name", registration.Name, DbType.String);
            dbParam.Add("Mobile", registration.Mobile, DbType.String);
            dbParam.Add("Email", registration.Email, DbType.String);
            dbParam.Add("Password", registration.Password, DbType.String);
            dbParam.Add("GenderID", registration.GenderID, DbType.Int32);
            dbParam.Add("StateRegNo", registration.StateRegNo, DbType.String);
            dbParam.Add("Experience", registration.Experience, DbType.Int32);
            dbParam.Add("Address", registration.Address, DbType.String);
            dbParam.Add("SpecializationID", registration.SpecializationID, DbType.Int32);
            dbParam.Add("Qualification", registration.Qualification, DbType.String);
            dbParam.Add("Institution", registration.Institution, DbType.String);
            dbParam.Add("AboutMe", registration.AboutMe, DbType.String);
            dbParam.Add("DoctorsAvailability", registration.DoctorsAvailability, DbType.Boolean);
            dbParam.Add("ClinicName", registration.ClinicName, DbType.String);
            dbParam.Add("Photo", registration.Photo, DbType.String);
            dbParam.Add("StatusID", registration.StatusID, DbType.Int32);
            dbParam.Add("Expert", registration.Expert, DbType.Int32);

           
            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            var result = dapper.Execute("[dbo].[SP_Add_Registration]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }

        public int UpdateUser(Registration registration)
        {
            var dbParam = new DynamicParameters();

            dbParam.Add("RegistrationID", registration.RegistrationID, DbType.Int32);
            dbParam.Add("RoleID", registration.RoleID, DbType.Int32);
            dbParam.Add("Name", registration.Name, DbType.String);
            dbParam.Add("Mobile", registration.Mobile, DbType.String);
            dbParam.Add("Email", registration.Email, DbType.String);
            dbParam.Add("Password", registration.Password, DbType.String);
            dbParam.Add("GenderID", registration.GenderID, DbType.Int32);
            dbParam.Add("StateRegNo", registration.StateRegNo, DbType.String);
            dbParam.Add("Experience", registration.Experience, DbType.Int32);
            dbParam.Add("Address", registration.Address, DbType.String);
            dbParam.Add("SpecializationID", registration.SpecializationID, DbType.Int32);
            dbParam.Add("Qualification", registration.Qualification, DbType.String);
            dbParam.Add("Institution", registration.Institution, DbType.String);
            dbParam.Add("AboutMe", registration.AboutMe, DbType.String);
            dbParam.Add("DoctorsAvailability", registration.DoctorsAvailability, DbType.Boolean);
            dbParam.Add("ClinicName", registration.ClinicName, DbType.String);
            dbParam.Add("Photo", registration.Photo, DbType.String);
            dbParam.Add("StatusID", registration.StatusID, DbType.Int32);
            dbParam.Add("Expert", registration.Expert, DbType.Int32);
          
            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            var result = dapper.Execute("[dbo].[SP_Update_Registration]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;


        }
        public int DeleteUser(Registration registration)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("RegistrationID", registration.RegistrationID, DbType.Int32);

            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            var result = dapper.Execute("[dbo].[SP_Delete_Registration]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
    }
}
