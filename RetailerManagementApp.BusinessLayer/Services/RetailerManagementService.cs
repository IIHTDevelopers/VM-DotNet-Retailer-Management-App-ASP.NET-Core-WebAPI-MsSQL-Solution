using RetailerManagementApp.BusinessLayer.Interfaces;
using RetailerManagementApp.BusinessLayer.Services.Repository;
using RetailerManagementApp.BusinessLayer.ViewModels;
using RetailerManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailerManagementApp.BusinessLayer.Services
{
    public class RetailerManagementService : IRetailerManagementService
    {
        private readonly IRetailerManagementRepository _repo;

        public RetailerManagementService(IRetailerManagementRepository repo)
        {
            _repo = repo;
        }

        public async Task<Retailer> CreateRetailer(Retailer employeeRetailer)
        {
            return await _repo.CreateRetailer(employeeRetailer);
        }

        public async Task<bool> DeleteRetailerById(long id)
        {
            return await _repo.DeleteRetailerById(id);
        }

        public List<Retailer> GetAllRetailers()
        {
            return  _repo.GetAllRetailers();
        }

        public async Task<Retailer> GetRetailerById(long id)
        {
            return await _repo.GetRetailerById(id);
        }

        public async Task<Retailer> UpdateRetailer(RetailerViewModel model)
        {
           return await _repo.UpdateRetailer(model);
        }
    }
}
