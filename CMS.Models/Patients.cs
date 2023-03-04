using System;

namespace CMS.Models
{
    public class Patients
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int StateID { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        public int GenderID { get; set; }
        public int RoleID { get; set; }
        public string ReferBy { get; set; }
        public string Action { get; set; }




    }
    public class RegisterPatientAppointment
    {
        public int PatientID { get; set;}
        public string PatientName { get; set;}
        public string PatientLastName { get; set; }    
        public string Mobile { get; set;}       
        public int Age { get; set; }
        public int GenderID { get; set; }       
       
        public int AppointmentID { get; set; }
        public int RegistrationID { get; set; }
        public int ServiceID { get; set; }
        public string Slot { get; set; }
        public int SlotID { get; set; }

        public int StatusID { get; set; }
        public string ServiceDate { get; set; }
        public int PriceID { get; set; }
        public decimal Payment { get; set; }
        public decimal DuePayment { get; set; }        
        public int DiscountID { get; set; }
        public string AppointmentBill { get; set; }
        public int ModeofPaymentID { get; set; }
        public string PatientStatus { get; set; }

    }

    public class PatientsDetails
    {
        public int PatientID { get; set; }
        public string Patient { get; set; }

        public string Mobile { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }

        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }

        public string Gender { get; set; }

        public int GenderID { get; set; }


        public string RoleName { get; set; }


        public string ReferBy { get; set; }



    }

    
}
