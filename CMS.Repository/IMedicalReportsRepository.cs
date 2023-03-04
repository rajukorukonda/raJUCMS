using CMS.Models;
using System.Collections.Generic;

namespace CMS.Repository
{
    public interface IMedicalReportsRepository
    {
        int AddMedicalReport(MedicalReports medicalReports);
        int UpdateMedicalReport(MedicalReports medicalReports);
        int DeleteMedicalReport(MedicalReports medicalReports);
        List<MedicalReports> GetAllMedicalReports();
        MedicalReports GetMedicalReport(int MedicalReportID);

    }
}
