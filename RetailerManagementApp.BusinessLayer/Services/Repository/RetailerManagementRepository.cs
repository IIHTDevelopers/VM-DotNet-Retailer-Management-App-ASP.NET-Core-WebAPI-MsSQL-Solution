using Microsoft.EntityFrameworkCore;
using RetailerManagementApp.BusinessLayer.ViewModels;
using RetailerManagementApp.DataLayer;
using RetailerManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RetailerManagementApp.BusinessLayer.Services.Repository
{
    public class RetailerManagementRepository : IRetailerManagementRepository
    {
        private readonly RetailerManagementAppDbContext _dbContext;
        public RetailerManagementRepository(RetailerManagementAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Retailer> CreateRetailer(Retailer RetailerModel)
        {
            try
            {
                var result = await _dbContext.Retailers.AddAsync(RetailerModel);
                await _dbContext.SaveChangesAsync();
                return RetailerModel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteRetailerById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Retailers.Single(a => a.RetailerId== id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Retailer> GetAllRetailers()
        {
            try
            {
                var result = _dbContext.Retailers.
                OrderByDescending(x => x.RetailerId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Retailer> GetRetailerById(long id)
        {
            try
            {
                return await _dbContext.Retailers.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
        public async Task<Retailer> UpdateRetailer(RetailerViewModel model)
        {
            var Retailer = await _dbContext.Retailers.FindAsync(model.RetailerId);
            try
            {

                _dbContext.Retailers.Update(Retailer);
                await _dbContext.SaveChangesAsync();
                return Retailer;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}