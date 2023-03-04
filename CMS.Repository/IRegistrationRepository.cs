using CMS.Models;
using System.Collections.Generic;

namespace CMS.Repository
{
    public interface IRegistrationRepository
    {
        int AddUser(Registration registration);
        int UpdateUser(Registration registration);
        int DeleteUser(Registration registration);
        List<Registration> GetAllUsers();
        Registration GetUser(int RegistrationID);
    }
}
