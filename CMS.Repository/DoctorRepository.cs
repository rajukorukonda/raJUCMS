using CMS.Models;
using CMS.Service;
using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Cors;

namespace CMS.Repository
{
    [EnableCors("CorsPolicy")]
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IDapper dapper;
        public DoctorRepository(IDapper _dapper)
        {
            dapper = _dapper;
        }
        //public int AddDoctor(Doctor doctor)
        //{
        //    var dbParam = new DynamicParameters();


        //    dbParam.Add("DoctorID", doctor.DoctorID, DbType.Int32);
        //    dbParam.Add("Name", doctor.Name, DbType.String);
        //    dbParam.Add("MobileNumber", doctor.MobileNumber, DbType.String);
        //    dbParam.Add("DeptId", doctor.DeptId, DbType.Int32);
        //    dbParam.Add("Experience", doctor.Experience, DbType.String);
        //    dbParam.Add("GenderId", doctor.GenderId, DbType.Int32);
        //    dbParam.Add("Qualification", doctor.Experience, DbType.String);
        //    dbParam.Add("Center", doctor.Center, DbType.String);
        //    dbParam.Add("Email", doctor.Email, DbType.String);
        //    dbParam.Add("Address", doctor.Address, DbType.String);
        //    dbParam.Add("RoleId", doctor.RoleId, DbType.Int32);
        //    dbParam.Add("Password", doctor.Password, DbType.String);
        //    dbParam.Add("Action", doctor.Action, DbType.String);
        //    dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
        //    var result = dapper.Execute("[dbo].[SP_Insert_Doctor]"
        //         , dbParam,
        //         commandType: CommandType.StoredProcedure);
        //    return result;

        //}
        //public int AddUpdateDoctor(Doctor doctor)
        //{
        //    var dbParam = new DynamicParameters();


        //    dbParam.Add("DoctorID", doctor.DoctorID, DbType.Int32);
        //    dbParam.Add("Name", doctor.Name, DbType.String);
        //    dbParam.Add("MobileNumber", doctor.MobileNumber, DbType.String);
        //    dbParam.Add("DeptId", doctor.DeptId, DbType.Int32);
        //    dbParam.Add("Experience", doctor.Experience, DbType.String);
        //    dbParam.Add("GenderId", doctor.GenderId, DbType.Int32);
        //    dbParam.Add("Qualification", doctor.Experience, DbType.String);
        //    dbParam.Add("Center", doctor.Center, DbType.String);
        //    dbParam.Add("Email", doctor.Email, DbType.String);
        //    dbParam.Add("Address", doctor.Address, DbType.String);
        //    dbParam.Add("RoleId", doctor.RoleId, DbType.Int32);
        //    dbParam.Add("Password", doctor.Password, DbType.String);
        //    dbParam.Add("Action", doctor.Action, DbType.String);
        //    dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
        //    var result = dapper.Execute("[dbo].[SP_InsertUpdate_Doctor]"
        //         , dbParam,
        //         commandType: CommandType.StoredProcedure);
        //    return result;

        //}

        //public int DeleteDoctor(int DoctorID)
        //{
        //    var dbParam = new DynamicParameters();
        //    dbParam.Add("DoctorID", DoctorID, DbType.Int32);

        //    dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
        //    var result = dapper.Execute("[dbo].[SP_Delete_Doctor]"
        //         , dbParam,
        //         commandType: CommandType.StoredProcedure);
        //    return result;

        //}

        public Doctors GetDoctor(int DoctorID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("DoctorID", DoctorID, DbType.Int32);
            var result = dapper.Get<Doctors>("[dbo].[SP_Get_Doctor]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<Doctors> GetAllDoctors()
        {
            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<Doctors>("[dbo].[SP_Get_Doctors]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }


    }
}
