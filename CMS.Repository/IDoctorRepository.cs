using CMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Repository
{
    public interface IDoctorRepository
    {
        //int AddUpdateDoctor(Doctor doctor);
        //int AddDoctor(Doctor doctor);       

        List<Doctors> GetAllDoctors();
        Doctors GetDoctor(int DoctorID);
        //int DeleteDoctor(int DoctorID);

    }
}
