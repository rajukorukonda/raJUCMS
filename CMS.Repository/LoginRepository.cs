using CMS.Models;
using CMS.Service;
using Dapper;
using Microsoft.AspNetCore.Cors;
using System.Data;

namespace CMS.Repository
{
    [EnableCors("CorsPolicy")]
    public class LoginRepository : ILoginRepository
    {
        private readonly IDapper dapper;
        public LoginRepository(IDapper _dapper)
        {
            dapper = _dapper;
        }
        public Login CheckUserExist(Login login)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("Name", login.Name, DbType.String);
            dbParam.Add("Password", login.Password, DbType.String);
            var result = dapper.Get<Login>("[dbo].[SP_Login]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
    }
}
