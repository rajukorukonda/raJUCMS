using CMS.Models;
using CMS.Service;
using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Cors;

namespace CMS.Repository
{
    [EnableCors("CorsPolicy")]
    public class MedicalReportsRepository : IMedicalReportsRepository
    {
        private readonly IDapper dapper;
        public MedicalReportsRepository(IDapper _dapper)
        {
            dapper = _dapper;
        }
        public MedicalReports GetMedicalReport(int MedicalReportID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("MedicalReportID", MedicalReportID, DbType.Int32);

            var result = dapper.Get<MedicalReports>("[dbo].[SP_Get_MedicalReport]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<MedicalReports> GetAllMedicalReports()
        {

            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<MedicalReports>("[dbo].[SP_Get_AllMedicalReports]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public int AddMedicalReport(MedicalReports medicalReports)
        {
            var dbParam = new DynamicParameters();

            dbParam.Add("MedicalReportID", medicalReports.MedicalReportID, DbType.Int32);
            dbParam.Add("AppointmentID", medicalReports.AppointmentID, DbType.Int32);
            dbParam.Add("DocumentTypeID", medicalReports.DocumentTypeID, DbType.Int32);
            dbParam.Add("FilePath", medicalReports.FilePath, DbType.String);
            dbParam.Add("TypeofReportID", medicalReports.TypeofReportID, DbType.Int32);
           
            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            var result = dapper.Execute("[dbo].[SP_Add_MedicalReports]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }

        public int UpdateMedicalReport(MedicalReports medicalReports)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("MedicalReportID", medicalReports.MedicalReportID, DbType.Int32);
            dbParam.Add("AppointmentID", medicalReports.AppointmentID, DbType.Int32);
            dbParam.Add("DocumentTypeID", medicalReports.DocumentTypeID, DbType.Int32);
            dbParam.Add("FilePath", medicalReports.FilePath, DbType.String);
            dbParam.Add("TypeofReportID", medicalReports.TypeofReportID, DbType.Int32);
         
            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            var result = dapper.Execute("[dbo].[SP_Update_MedicalReports]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;


        }
        public int DeleteMedicalReport(MedicalReports medicalReports)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("MedicalReportID", medicalReports.MedicalReportID, DbType.Int32);

            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            var result = dapper.Execute("[dbo].[SP_Delete_MedicalReports]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
    }
}
