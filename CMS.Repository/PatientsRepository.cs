using CMS.Models;
using CMS.Service;
using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Cors;

namespace CMS.Repository
{
    [EnableCors("CorsPolicy")]
    public class PatientsRepository : IPatientsRepository
    {
        private readonly IDapper dapper;
        public PatientsRepository(IDapper _dapper)
        {
            dapper = _dapper;
        }
        public PatientsDetails GetPatient(int PatientID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("PatientID", PatientID, DbType.Int32);
            var result = dapper.Get<PatientsDetails>("[dbo].[SP_Get_Patient]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        //public List<PatientsDetails> GetAllPatients()
        //{
        //    var dbParam = new DynamicParameters();

        //    var result = dapper.GetAll<PatientsDetails>("[dbo].[SP_Get_AllPatients]"
        //         , dbParam,
        //         commandType: CommandType.StoredProcedure);
        //    return result;

        //}


        public List<PatientsDetails> GetAllPatients()
        {
            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<PatientsDetails>("[dbo].[SP_Get_AllPatients]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }


        public int AddUpdatePatient(Patients patients)
        {
            var dbParam = new DynamicParameters();

            dbParam.Add("PatientID", patients.PatientID, DbType.Int32);
            dbParam.Add("PatientName", patients.PatientName, DbType.String);
            dbParam.Add("PatientLastName", patients.PatientLastName, DbType.String);
            dbParam.Add("Mobile", patients.Mobile, DbType.String);
            dbParam.Add("Email", patients.Email, DbType.String);
            dbParam.Add("Address", patients.Address, DbType.String);
            dbParam.Add("StateID", patients.StateID, DbType.Int32);
            dbParam.Add("City", patients.City, DbType.String);
            dbParam.Add("Pincode", patients.Pincode, DbType.String);
            dbParam.Add("DOB", patients.DOB, DbType.String);
            dbParam.Add("Age", patients.Age, DbType.Int32);
            dbParam.Add("GenderID", patients.GenderID, DbType.Int32);
            dbParam.Add("RoleID", patients.RoleID, DbType.Int32);
            dbParam.Add("ReferBy", patients.ReferBy, DbType.String);

            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            var result = dapper.Execute("[dbo].[SP_InsertUpdate_Patients]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public int AddRegisterPatientAppointment(RegisterPatientAppointment registerPatientAppointment)
        {
            var dbParam = new DynamicParameters();

            dbParam.Add("PatientID", registerPatientAppointment.PatientID, DbType.Int32);
            dbParam.Add("PatientName", registerPatientAppointment.PatientName, DbType.String);
            dbParam.Add("PatientLastName", registerPatientAppointment.PatientLastName, DbType.String);
            dbParam.Add("Mobile", registerPatientAppointment.Mobile, DbType.String);          
            dbParam.Add("Age", registerPatientAppointment.Age, DbType.Int32);
            dbParam.Add("GenderID", registerPatientAppointment.GenderID, DbType.Int32);
            dbParam.Add("AppointmentID", registerPatientAppointment.AppointmentID, DbType.Int32);
            dbParam.Add("RegistrationID", registerPatientAppointment.RegistrationID, DbType.Int32);           
            dbParam.Add("ServiceID", registerPatientAppointment.ServiceID, DbType.Int32);
           
            dbParam.Add("SlotID", registerPatientAppointment.SlotID, DbType.Int32);
            dbParam.Add("StatusID", registerPatientAppointment.StatusID, DbType.Int32);
            dbParam.Add("ServiceDate", registerPatientAppointment.ServiceDate, DbType.String);
            dbParam.Add("PriceID", registerPatientAppointment.PriceID, DbType.Int32);
            dbParam.Add("Payment", registerPatientAppointment.Payment, DbType.String);
            dbParam.Add("DuePayment", registerPatientAppointment.DuePayment, DbType.String);
            dbParam.Add("DiscountID", registerPatientAppointment.DiscountID, DbType.Int32);
            dbParam.Add("AppointmentBill", registerPatientAppointment.AppointmentBill, DbType.String);
            dbParam.Add("ModeofPaymentID", registerPatientAppointment.ModeofPaymentID, DbType.Int32);
            dbParam.Add("Slot", registerPatientAppointment.Slot, DbType.String);
            dbParam.Add("PatientStatus", registerPatientAppointment.PatientStatus, DbType.String);
            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            var result = dapper.Execute("[dbo].[SP_Insert_RegisterPatientAppointment]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }


        public int DeletePatient(Patients patients)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("PatientID", patients.PatientID, DbType.Int32);

            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            var result = dapper.Execute("[dbo].[SP_Delete_Patients]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
    }
}
