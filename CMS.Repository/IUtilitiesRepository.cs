using CMS.Models;
using System.Collections.Generic;

namespace CMS.Repository
{
    public interface IUtilitiesRepository
    {
        List<AppointmentBill> GetAllAppointmentBills();
        AppointmentBill GetAppointmentBill(int PriceID);
        List<State> GetAllStates();
        State GetState(int StateID);
        List<Services> GetServices();
        Services GetService(int ServiceID);
        List<Slots> GetSlots();
        Slots GetSlot(int SlotID);
        List<Genders> GetAllGenders();
        Genders GetGender(int GenderID);
        List<MOP> GetAllMOP();
        MOP GetMOP(int ModeofPaymentID);
        List<Status> GetStatuses();
        Status GetStatus(int StatusID);
        List<Roles> GetAllRoles();
        Roles GetRole(int RoleID);
        List<Specialization> GetAllSpecializations();
        Specialization GetSpecialization(int SpecializationID);
        List<TypeofReports> GetAllTypeofReports();
        TypeofReports GetTypeofReport(int TypeofReportID);
        List<Discounts> GetAllDiscounts();
        Discounts GetDiscount(int DiscountID);
    }
}
