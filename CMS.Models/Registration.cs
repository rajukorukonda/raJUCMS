using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class Registration
    {
        public int RegistrationID { get; set; }
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int GenderID { get; set; }
        public string StateRegNo { get; set; }
        public int Experience { get; set; }
        public string Address { get; set; }
        public int SpecializationID { get; set; }
        public string Qualification { get; set; }
        public string Institution { get; set; }
        public string AboutMe { get; set; }
        public bool DoctorsAvailability { get; set; }
        public string ClinicName { get; set; }
        public string Photo { get; set; }
        public int StatusID { get; set; }
        public int Expert { get; set; }

    }
}
