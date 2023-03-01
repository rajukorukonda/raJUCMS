using CMS.Models;
using CMS.Service;
using Dapper;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CMS.Repository
{
    [EnableCors("CorsPolicy")]
    public class UtilitiesRepository : IUtilitiesRepository
    {
        private readonly IDapper dapper;
        public UtilitiesRepository(IDapper _dapper)
        {
            dapper = _dapper;
        }
        public AppointmentBill GetAppointmentBill(int PriceID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("PriceID", PriceID, DbType.Int32);

            var result = dapper.Get<AppointmentBill>("[dbo].[SP_Get_AppointmentBill]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            //var result = (from price in result orderby price ascending select result);
            return result;

        }

        public List<AppointmentBill> GetAllAppointmentBills()
        {

            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<AppointmentBill>("[dbo].[SP_Get_AllAppointmentBill]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            result = result.OrderBy(o => o.Price).ToList();
            return result;

        }
        public State GetState(int StateID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("StateID", StateID, DbType.Int32);

            var result = dapper.Get<State>("[dbo].[SP_Get_State]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<State> GetAllStates()
        {

            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<State>("[dbo].[SP_Get_AllStates]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public Services GetService(int ServiceID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("ServiceID", ServiceID, DbType.Int32);
            var result = dapper.Get<Services>("[dbo].[SP_Get_Service]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<Services> GetServices()
        {
            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<Services>("[dbo].[SP_Get_AllServices]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public Slots GetSlot(int SlotID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("SlotID", SlotID, DbType.Int32);

            var result = dapper.Get<Slots>("[dbo].[SP_Get_Slot]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<Slots> GetSlots()
        {

            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<Slots>("[dbo].[SP_Get_Slots]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public Genders GetGender(int GenderID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("GenderID", GenderID, DbType.Int32);

            var result = dapper.Get<Genders>("[dbo].[SP_Get_Gender]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<Genders> GetAllGenders()
        {

            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<Genders>("[dbo].[SP_Get_Genders]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public MOP GetMOP(int ModeofPaymentID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("ModeofPaymentID", ModeofPaymentID, DbType.Int32);

            var result = dapper.Get<MOP>("[dbo].[SP_Get_MOP]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<MOP> GetAllMOP()
        {

            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<MOP>("[dbo].[SP_Get_AllMOP]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public Status GetStatus(int StatusId)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("StatusId", StatusId, DbType.Int32);
            var result = dapper.Get<Status>("[dbo].[SP_Get_Status]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<Status> GetStatuses()
        {
            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<Status>("[dbo].[SP_Get_Statuses]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public Roles GetRole(int RoleID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("RoleID", RoleID, DbType.Int32);

            var result = dapper.Get<Roles>("[dbo].[SP_Get_Role]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<Roles> GetAllRoles()
        {

            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<Roles>("[dbo].[SP_Get_Roles]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public Specialization GetSpecialization(int SpecializationID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("SpecializationID", SpecializationID, DbType.Int32);
            var result = dapper.Get<Specialization>("[dbo].[SP_Get_Specialization]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<Specialization> GetAllSpecializations()
        {
            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<Specialization>("[dbo].[SP_Get_Specializations]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public TypeofReports GetTypeofReport(int TypeofReportID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("TypeofReportID", TypeofReportID, DbType.Int32);

            var result = dapper.Get<TypeofReports>("[dbo].[SP_Get_TypeofReport]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<TypeofReports> GetAllTypeofReports()
        {

            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<TypeofReports>("[dbo].[SP_Get_AllTypeofReport]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public Discounts GetDiscount(int DiscountID)
        {
            var dbParam = new DynamicParameters();
            dbParam.Add("DiscountID", DiscountID, DbType.Int32);

            var result = dapper.Get<Discounts>("[dbo].[SP_Get_Discount%]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<Discounts> GetAllDiscounts()
        {

            var dbParam = new DynamicParameters();

            var result = dapper.GetAll<Discounts>("[dbo].[SP_Get_AllDiscount%]"
                 , dbParam,
                 commandType: CommandType.StoredProcedure);
            result = result.OrderBy(o => o.Discount).ToList();
            return result;

        }
    }
}
