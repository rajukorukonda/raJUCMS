using CMS.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace CMS.Repository
{
    public interface IPatientsAppointmentsRepository
    {
        int AddUpdateAppointment(PatientsAppointments patientsAppointments);
        int DeleteAppointment(PatientsAppointments patientsAppointments);
        List<AppointmentDetails> GetAllAppointments();
        List<MedicineList> GetMedicineList();
        int AddUpdateMedicine(List<MedicineList> patientsAppointments);
        List<AppointmentDetails> GetAllAppointments_Distict();

        List<AppointmentDetails> GetReportPatientList(ReportList reportList);

        AppointmentDetails GetAppointment(int AppointmentID);

        public dynamic VitalsCRUD(List<Vitals> vitals);
        public dynamic RegisterationCRUD(List<Registeration> registeration);


        public dynamic DoctorsAvailability(List<DoctorsAvailability> docsAvail);
        public dynamic DocsCrud(List<Docs>docs);
        public dynamic DoctorsAvailabilitySlots(List<DoctorsAvailability> docs);
        public dynamic GetAvailabilityXML(List<DoctorsAvailability> docs);

        public dynamic GetComplaintsXML(ComplaintsList complaintsList);

        public dynamic GetDocumentsXML(VitalDocs vitalDocs);
        public dynamic GetMedicineXML(MedicationList medicationList);
        public dynamic VisitReason_Crud(List<VisitReason> visitReason);
        public dynamic PatientHistory(List<PatientHistory> visitReason);

        public dynamic ComplaintsCrud(List<Complaints> complaints);

        //public dynamic DocsCrud1(string data);

    }
}
