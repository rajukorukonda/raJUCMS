using CMS.Models;

namespace CMS.Repository
{
    public interface ILoginRepository
    {
        Login CheckUserExist(Login login);
    }
}
