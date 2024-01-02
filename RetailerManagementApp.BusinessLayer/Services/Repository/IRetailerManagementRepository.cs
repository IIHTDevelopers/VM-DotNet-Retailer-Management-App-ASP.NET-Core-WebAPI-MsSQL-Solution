using RetailerManagementApp.BusinessLayer.ViewModels;
using RetailerManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RetailerManagementApp.BusinessLayer.Services.Repository
{
    public interface IRetailerManagementRepository
    {
        List<Retailer> GetAllRetailers();
        Task<Retailer> CreateRetailer(Retailer retailer);
        Task<Retailer> GetRetailerById(long id);
        Task<bool> DeleteRetailerById(long id);
        Task<Retailer> UpdateRetailer(RetailerViewModel model);
    }
}
