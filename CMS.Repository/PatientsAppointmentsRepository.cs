using CMS.Models;
using CMS.Service;
using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace CMS.Repository
{
    [EnableCors("CorsPolicy")]
    public class PatientsAppointmentsRepository : IPatientsAppointmentsRepository
    {
        private readonly IDapper dapper;
        public XmlProviders xml;

        public PatientsAppointmentsRepository(IDapper _dapper)
        {
            dapper = _dapper;
        }
        public PatientsAppointmentsRepository(XmlProviders _xml)
        {
            xml = _xml;
        }
        public string GetXmlArrayString<T>(List<T> listDetails)
        {
            string xml = "";
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<T>));
                xs.Serialize(sw, listDetails);
                xml = sw.ToString().Replace("utf-16", "utf-8");
            }
            string ReplaceXML = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", " ").Trim();
            string ReplaceXmlTable = ReplaceXML.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "").Trim();
            xml = ReplaceXmlTable.Replace("xsi:nil=\"true\"", "").Replace("xsi:type=\"xsd:boolean\"", "").Replace("xsi:type=\"xsd:string\"", "");
            return xml;
        }
        public AppointmentDetails GetAppointment(int AppointmentID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("AppointmentID", AppointmentID, DbType.Int32);

            var result = dapper.Get<AppointmentDetails>("[dbo].[SP_Get_PatientsAppointments]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<AppointmentDetails> GetAllAppointments()
        {

            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<AppointmentDetails>("[dbo].[SP_Get_AllPatientsAppointments]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }

        public List<MedicineList> GetMedicineList()
        {

            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<MedicineList>("[dbo].[SP_Get_AllMedicineList]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }

        public int AddUpdateMedicine(List<MedicineList> medicine)
        {

            var dbParam = new DynamicParameters();

            dbParam.Add("MedicineId", medicine[0].MedicineId, DbType.Int32);
            dbParam.Add("MedicineName", medicine[0].MedicineName, DbType.String);
            dbParam.Add("Composition", medicine[0].Composition, DbType.String);
           // dbParam.Add("CreatedDate", medicine.CreatedDate, DbType.String);
           // dbParam.Add("ModifiedDate", medicine.ModifiedDate, DbType.String);
           // dbParam.Add("IsDelete", medicine.IsDelete, DbType.String);
            dbParam.Add("Action", medicine[0].Action, DbType.String);

            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            var result = dapper.Execute("[dbo].[SP_InsertUpdate_Medicine]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }



        public List<AppointmentDetails> GetAllAppointments_Distict()
        {

            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<AppointmentDetails>("[dbo].[SP_Get_AllPatientsAppointments_Distict]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }

        public List<AppointmentDetails> GetReportPatientList(ReportList reportList)
        {

            var dbParam = new DynamicParameters();

            dbParam.Add("FromDate", reportList.FromDate, DbType.String);
            dbParam.Add("ToDate", reportList.ToDate, DbType.String);

            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);

            var result = dapper.GetAll<AppointmentDetails>("[dbo].[SP_Get_AllReportPatientsAppointments]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

            //var dbParam = new DynamicParameters();
            //dbParam.Add("AppointmentID", patientsAppointments.AppointmentID, DbType.Int32);

            //dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            //var result = dapper.Execute("[dbo].[SP_Delete_PatientsAppointments]"
            //     , dbParam,
            //     commandType: CommandType.StoredProcedure);
            //return result;

        }
        public int AddUpdateAppointment(PatientsAppointments patientsAppointments)
        {
       
            var dbParam = new DynamicParameters();

            dbParam.Add("AppointmentID", patientsAppointments.AppointmentID, DbType.Int32);
            dbParam.Add("RegistrationID", patientsAppointments.RegistrationID, DbType.Int32);
            dbParam.Add("PatientID", patientsAppointments.PatientID, DbType.Int32);
            dbParam.Add("ServiceID", patientsAppointments.ServiceID, DbType.Int32);
            dbParam.Add("Slot", patientsAppointments.Slot, DbType.String);
            dbParam.Add("SlotID", patientsAppointments.SlotID, DbType.Int32);
            dbParam.Add("StatusID", patientsAppointments.StatusID, DbType.Int32);
            dbParam.Add("ServiceDate", patientsAppointments.ServiceDate, DbType.String);
            dbParam.Add("PriceID", patientsAppointments.PriceID, DbType.Int32);
            dbParam.Add("Payment", patientsAppointments.Payment, DbType.String);
            dbParam.Add("DuePayment", patientsAppointments.DuePayment, DbType.String);
            dbParam.Add("DiscountID", patientsAppointments.DiscountID, DbType.Int32);
            dbParam.Add("AppointmentBill", patientsAppointments.AppointmentBill, DbType.String);
            dbParam.Add("ModeofPaymentID", patientsAppointments.ModeofPaymentID, DbType.Int32);
            dbParam.Add("Action", patientsAppointments.Action, DbType.String);
            dbParam.Add("PatientStatus", patientsAppointments.PatientStatus, DbType.String);
            dbParam.Add("PatientName", patientsAppointments.PatientName, DbType.String);
            dbParam.Add("PatientLastName", "", DbType.String);
            dbParam.Add("Age", patientsAppointments.Age, DbType.Int32);
            dbParam.Add("GenderID", patientsAppointments.GenderID, DbType.Int32);

            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            var result = dapper.Execute("[dbo].[SP_InsertUpdate_PatientsAppointments]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }

 
        public int DeleteAppointment(PatientsAppointments patientsAppointments)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("AppointmentID", patientsAppointments.AppointmentID, DbType.Int32);

            dbParam.Add("result", null, DbType.Int32, ParameterDirection.ReturnValue);
            var result = dapper.Execute("[dbo].[SP_Delete_PatientsAppointments]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public dynamic GetComplaintsXML(ComplaintsList cmplaintsList)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("Param1", cmplaintsList.VitalsID, DbType.Int32);
            var result = dapper.GetAll<ComplaintsList>("[dbo].[GetComplaintsXML]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }

        public dynamic GetDocumentsXML(VitalDocs cmplaintsList)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("Param1", cmplaintsList.VitalsID, DbType.Int32);
            var result = dapper.GetAll<VitalDocs>("[dbo].[GetDocumentsXML]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }

        public dynamic GetMedicineXML(MedicationList medicationList)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("Param1", medicationList.VitalsID, DbType.Int32);
            var result = dapper.GetAll<MedicationList>("[dbo].[GetMedicineXML]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }





        public dynamic VitalsCRUD(List<Vitals> vitals)
        {
            string VitalsXML = GetXmlArrayString<Vitals>(vitals);
            string ComplaintsXML = GetXmlArrayString<ComplaList>(vitals[0].comp);
            string MedicineXML = GetXmlArrayString<MedicationList>(vitals[0].medicine);
            // string DocsXML = GetXmlArrayString<DocsList>(vitals[0].docs);
            string DocsXML = GetXmlArrayString<VitalDocs>(vitals[0].vitalDocs);
            string status = vitals[0].Status;
            var dbParam = new DynamicParameters();
            dbParam.Add("VitalsXML", VitalsXML, DbType.Xml);
            dbParam.Add("ComplaintsXML", ComplaintsXML, DbType.Xml);
            dbParam.Add("DocsXML", DocsXML, DbType.Xml);
            dbParam.Add("MedicineXML", MedicineXML, DbType.Xml);
            dbParam.Add("Param1", vitals[0].flag, DbType.Int32);
            dbParam.Add("Status", status, DbType.String);
            dbParam.Add("result", null, DbType.String, ParameterDirection.ReturnValue);
            if (vitals[0].flag == 4)
            {
                var result = dapper.GetAll<Vitals>("[dbo].[VitalsCRUD]", dbParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            else
            {
                var result = dapper.Execute("[dbo].[VitalsCRUD]", dbParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            

        }

   

        public dynamic DocsCrud(List<Docs> docs)
        {
            string DocsXML = GetXmlArrayString<Docs>(docs);
            var dbParam = new DynamicParameters();
            dbParam.Add("xmlParam", DocsXML, DbType.Xml);
            dbParam.Add("Param1", docs[0].flag, DbType.Int32);
            dbParam.Add("result", null, DbType.String, ParameterDirection.ReturnValue);
            var result = dapper.GetAll<Docs>("[dbo].[DocsCrud]",dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
      

        public dynamic VisitReason_Crud(List<VisitReason> visitReason)
        {

            string DocsXML = GetXmlArrayString<VisitReason>(visitReason);
            var dbParam = new DynamicParameters();
            dbParam.Add("xmlParam", DocsXML, DbType.Xml);
            dbParam.Add("Param1", visitReason[0].flag, DbType.Int32);
            dbParam.Add("result", null, DbType.String, ParameterDirection.ReturnValue);

            var result = dapper.GetAll<VisitReason>("[dbo].[VisitReason_Crud]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public dynamic PatientHistory(List<PatientHistory> visitReason)
        {

            string DocsXML = GetXmlArrayString<PatientHistory>(visitReason);
            var dbParam = new DynamicParameters();
            dbParam.Add("Param1", visitReason[0].PatientID, DbType.Int32);
            dbParam.Add("result", null, DbType.String, ParameterDirection.ReturnValue);

            var result = dapper.GetAll<PatientHistory>("[dbo].[PatientHistory]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public dynamic ComplaintsCrud(List<Complaints> complaints)
        {

            string DocsXML = GetXmlArrayString<Complaints>(complaints);
            var dbParam = new DynamicParameters();
            dbParam.Add("xmlParam", DocsXML, DbType.Xml);
            dbParam.Add("Param1", complaints[0].flag, DbType.Int32);
            dbParam.Add("result", null, DbType.String, ParameterDirection.ReturnValue);
            var result = dapper.GetAll<Complaints>("[dbo].[ComplaintsCrud]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }




        public dynamic RegisterationCRUD(List<Registeration> registeration)
        {
            registeration[0].DoctorsAvailability = true;
            string VitalsXML = GetXmlArrayString<Registeration>(registeration);
            var dbParam = new DynamicParameters();
            dbParam.Add("xmlParam", VitalsXML, DbType.Xml);
            dbParam.Add("Param1", registeration[0].flag, DbType.Int32);
            dbParam.Add("result", null, DbType.String, ParameterDirection.ReturnValue);
            if (registeration[0].flag == 4)
            {
                var result = dapper.GetAll<Registeration>("[dbo].[RegisterationCRUD]", dbParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            else
            {
                var result = dapper.Execute("[dbo].[RegisterationCRUD]", dbParam, commandType: CommandType.StoredProcedure);
                return result;
            }


        }



        public dynamic DoctorsAvailability(List<DoctorsAvailability> docsAvail)
        {
            string VitalsXML = GetXmlArrayString<DoctorsAvailability>(docsAvail);
            string SlotsXML = GetXmlArrayString<DoctorsAvailabilitySlots>(docsAvail[0].slots);
            var dbParam = new DynamicParameters();
            dbParam.Add("AvailabilityXML", VitalsXML, DbType.Xml);
            dbParam.Add("SlotsXML", SlotsXML, DbType.Xml);
            dbParam.Add("Param1", docsAvail[0].flag, DbType.Int32);
            dbParam.Add("result", null, DbType.String, ParameterDirection.ReturnValue);
            if (docsAvail[0].flag == 2)
            {
                var result = dapper.GetAll<DoctorsAvailability>("[dbo].[DoctorsAvailability]", dbParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            else
            {
                var result = dapper.Execute("[dbo].[DoctorsAvailability]", dbParam, commandType: CommandType.StoredProcedure);
                return result;
            }


        }
     

        public dynamic DoctorsAvailabilitySlots(List<DoctorsAvailability> docs)
        {
            string DocsXML = GetXmlArrayString<DoctorsAvailability>(docs);
            var dbParam = new DynamicParameters();
            dbParam.Add("DoctorDetais", docs[0].DoctorID, DbType.Int32);
            dbParam.Add("result", null, DbType.String, ParameterDirection.ReturnValue);
            var result = dapper.GetAll<slots>("[dbo].[GetDoctors_AvailabilitySlots]", dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public dynamic GetAvailabilityXML(List<DoctorsAvailability> docs)
        {
            string DocsXML = GetXmlArrayString<DoctorsAvailability>(docs);
            var dbParam = new DynamicParameters();
            dbParam.Add("Param1", docs[0].DoctorID, DbType.Int32);
            dbParam.Add("result", null, DbType.String, ParameterDirection.ReturnValue);
            var result = dapper.GetAll<DoctorsAvailabilitySlots>("[dbo].[GetAvailabilityXML]", dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
    }
}



