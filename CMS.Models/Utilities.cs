namespace CMS.Models
{
    public class Utilities
    {
    }
    public class State
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
    }

    public class Services
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
    }

    public class Slots
    {
        public int SlotID { get; set; }
        public string SlotTime { get; set; }
    }

    public class Genders
    {
        public int GenderID { get; set; }
        public string Gender { get; set; }
    }
    public class MOP
    {
        public int ModeofPaymentID { get; set; }    
        public string ModeofPayment { get; set; }   
    }
    public class Status
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }

    }
    public class Roles
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
    public class Specialization
    {
        public int SpecializationID { get; set; }
        public string Name { get; set; }

    }
    public class TypeofReports
    {
        public int TypeofReportID { get; set; }
        public string TypeofReport { get; set; }

    }
    public class Discounts
    {
        public int DiscountID { get; set; }
        public int Discount { get; set; }

    }
    public class AppointmentBill
    {
        public int PriceID { get; set; }
        public int Price { get; set; }

    }
}
