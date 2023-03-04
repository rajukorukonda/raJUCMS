using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class PatientsAppointments
    {
        public int PatientID { get; set; }
        public int RegistrationID { get; set; }
        public int AppointmentID { get; set; }
        public int ServiceID { get; set; }
        public int SlotID { get; set; }
        public int StatusID { get; set; }

        public string ServiceDate { get; set; }
        public int PriceID { get; set; }
        public decimal Payment { get; set; }
        public decimal DuePayment { get; set; }

        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public string Mobile { get; set; }
        public int Age { get; set; }
        public int GenderID { get; set; }
        public string Action { get; set; }

        public string Slot { get; set; }

        
        public int DiscountID { get; set; }
        public string AppointmentBill { get; set; }
        public int ModeofPaymentID { get; set; }
        public string PatientStatus { get; set; }




    }
    public class AppointmentDetails
    {
        public int VitalsID { get; set; }

        public int AppointmentID { get; set; }
        public string PatientARCID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }

        public string Doctor { get; set; }
        public string Patient { get; set; }
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public int SlotID { get; set; } 
        public string SlotTime { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public string ServiceDate { get; set; }
        public string AppointmentDate { get; set; }
        public int PriceID { get; set; }
        public string Price { get; set; }   
        public string Payment { get; set; }
        public string DuePayment { get; set; }
        public int DiscountID { get; set; } 
        public string Discount { get; set; }
        public string AppointmentBill { get; set; }
        public int ModeofPaymentID { get; set; }
       public string Mobile { get; set; }
        public int Age { get; set; }
        public int GenderID { get; set; }

        public string Gender { get; set; }
        public string ModeofPayment { get; set; }
        public DateTime CreatedDate { get; set; }   
        public DateTime UpdatedDate { get; set; }
        public int DoctorCompleted { get; set; }
        public string WaitingTime { get; set; }
       public int VisitCount { get; set; }
        public string Status { get; set; }
        public int ReceiptToken { get; set; }


    }

    public class Vitals
    {
        public int VitalsID         { get; set; }
        public int PatientID		  { get; set; }
        public int AppointmentID	  { get; set; }
        public string Weight			  { get; set; }
        public string BloodGroup		  { get; set; }
        public string Temperature_F	  { get; set; }
        public string Serum_Creatinine { get; set; }
        public string BP				  { get; set; }
        public string Pulse			  { get; set; }
        public string SpO2			  { get; set; }
        public string BMI			  { get; set; }
        public int VisitReasonID	  { get; set; }
        public int DoctorCompleted { get; set; }
        public List<ComplaList> comp { get; set; }
        public List<MedicationList> medicine { get; set; }
        public List<DocsList> docs { get; set; }
        public List<VitalDocs> vitalDocs { get; set; }


        
        public int flag { get; set; }
        public List<string> comp1 { get; set; }
        public string ComplaintIDs { get; set; }
        public string Advice { get; set; }
        public string NextVisit { get; set; }
        public string Frequency { get; set; }
        public DateTime? PickADate { get; set; }
        public string Status { get; set; }

    }
    public class ComplaintsList
    {
        public int VitalsID { get; set; }

        public string ComplaintIDs { get; set; }
        public string ComplaintName { get; set; }
    }
    public class ComplaList
    {

        public string ComplaintIDs { get; set; }
        public string ComplaintName { get; set; }
    }

    public class ReportList
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }

    public class MedicineList
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Composition { get; set; }
       // public string CreatedDate { get; set; }
      //  public string ModifiedDate { get; set; }
       // public string IsDelete { get; set; }
        public string Action { get; set; }
        
    }

    public class MedicationList
    {
        public int VitalsID { get; set; }
       // public int AppointmentID { get; set; }
        public string Medicine { get; set; }
        public string Dose { get; set; }
        public string When { get; set; }
        public string FrequencyListMedication { get; set; }
        public string Duration { get; set; }
        public string Notes { get; set; }
        public string Advice { get; set; }
        public string NextVisit { get; set; }
    }

    public class DocsList
    {
        public int VitalsID { get; set; }
        public string DocumentTypeID { get; set; }
        public String DocTypeNAme { get; set; }
    }
    public class Complaints
        {
       public string ComplaintIDs	  { get; set; }
       public int Documents { get; set; }

        public int ComplaintID   { get; set; }
        public String ComplaintName { get; set; }
        public Boolean? Status		  { get; set; }
        public DateTime? CreatedDate	  { get; set; }
        public int CreatedBy	  { get; set; }
        public DateTime? ModifiedDate  { get; set; }
        public int ModifiedBy { get; set; }
        public int flag { get; set; }
        public string Xml { get; set; }
    }

    public class Docs
    {
        public int Documents { get; set; }

        public int DocumentTypeID { get; set; }
        public String DocTypeNAme { get; set; }
        public Boolean? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public int flag { get; set; }
        public string Xml { get; set; }
        public List<VisitReason> VisitReason { get; set; }

    }

    public class VitalDocs
    {

        public int AppointmentID { get; set; }
        public int DocumentTypeID { get; set; }
        public String DocTypeNAme { get; set; }
        public String DocName { get; set; }

        public int VitalsID { get; set; }

    }
    public class VisitReason
    {
        public int VisitReasonID { get; set; }
        public String Reason { get; set; }
        public Boolean? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public int flag { get; set; }
        public string Xml { get; set; }
    }
    public class Registeration
    {
       
        public int RegistrationID      { get; set; }
        public int RoleID              { get; set; }
        public string Name				 { get; set; }
        public string Mobile				 { get; set; }
        public string Email				 { get; set; }
        public string Password			 { get; set; }
        public int GenderID			 { get; set; }
        public string StateRegNo			 { get; set; }
        public int Experience			 { get; set; }
        public string Address			 { get; set; }
        public int SpecializationID	 { get; set; }
        public string Qualification		 { get; set; }
        public string Institution		 { get; set; }
        public string AboutMe			 { get; set; }
        public Boolean? DoctorsAvailability { get; set; }
        public string ClinicName			 { get; set; }
        public string Photo				 { get; set; }
        public int StatusID			 { get; set; }
        public int Expert				 { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string IsDelete { get; set; }
        public int flag { get; set; }

    }

    public class DoctorsAvailability
    {
        public int DoctorAvailabilityID { get; set; }
        public int DoctorID { get; set; }

        public Boolean? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public int flag { get; set; }
        public List<DoctorsAvailabilitySlots> slots { get; set; }
    }
    public class DoctorsAvailabilitySlots
    {
        public int Day { get; set; }
        public string Start { get; set; }
        public string Ending { get; set; }
        

    }
    public class slots
    {
        public int day { get; set; }
        public int rowid { get; set; }
        public int Doctorid { get; set; }
        public string slot { get; set; }


    }
    public class PatientHistory
    {
        public int PatientID { get; set; }

        public string PatientName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string DoctorName { get; set; }
        public string Gender { get; set; }
        public string ServiceDate { get; set; }
        public string Weight { get; set; }
        public string BloodGroup { get; set; }
        public string Temperature_F { get; set; }
        public string Serum_Creatinine { get; set; }
        public string BP { get; set; }
        public string Pulse { get; set; }
        public string SpO2 { get; set; }
        public string BMI { get; set; }
        public int VisitReasonID { get; set; }
        public int AppointmentID { get; set; }
        public int GenderID { get; set; }
        public int VitalsID { get; set; }
        public string Reason { get; set; }

        public string ComplaintIDs { get; set; }
        public string Documents { get; set; }
        public string ServiceName { get; set; }





    }
}
