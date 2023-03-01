using CMS.Models;
using System.Collections.Generic;
namespace CMS.Repository
{
    public interface IPatientsRepository
    {
        int AddUpdatePatient(Patients patients);
        int AddRegisterPatientAppointment(RegisterPatientAppointment registerPatientAppointment);

        int DeletePatient(Patients patients);
        List<PatientsDetails> GetAllPatients();
   

        PatientsDetails GetPatient(int PatientID);
    }
}
