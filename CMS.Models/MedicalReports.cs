using System;

namespace CMS.Models
{
    public class MedicalReports
    {
        public int MedicalReportID { get; set; }
        public int AppointmentID { get; set; }
        public int DocumentTypeID { get; set; }
        public string FilePath { get; set; }
        public int TypeofReportID { get; set; }


    }
}
