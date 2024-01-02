
using Moq;
using RetailerManagementApp.BusinessLayer.Services;
using RetailerManagementApp.BusinessLayer.Services.Repository;
using RetailerManagementApp.BusinessLayer.ViewModels;
using RetailerManagementApp.DataLayer;
using RetailerManagementApp.Entities;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using RetailerManagementApp.BusinessLayer.Interfaces;

namespace RetailerManagementApp.Tests.TestCases
{
     public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly RetailerManagementAppDbContext _dbContext;

        private readonly IRetailerManagementService  _retailerService;
        public readonly Mock<IRetailerManagementRepository> retailerservice= new Mock<IRetailerManagementRepository >();

        private readonly Retailer _retailer;
        private readonly RetailerViewModel _retailerViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
             _retailerService = new RetailerManagementService(retailerservice.Object);
           
            _output = output;

            _retailer = new Retailer
            {
                RetailerId = 1,
                Name = "Retailer",
                DateOfBirth = DateTime.Now,
                Age = 2,
                MobileNumber = "6534231234"
            };

            _retailerViewModel = new RetailerViewModel
            {
                RetailerId = 1,
                Name = "Retailer",
                DateOfBirth = DateTime.Now,
                Age = 2,
                MobileNumber = "6534231234"
            };
        }
        
       
        [Fact]
        public async Task<bool> Testfor_Create_Retailer()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                retailerservice.Setup(repos => repos.CreateRetailer(_retailer)).ReturnsAsync(_retailer);
                var result = await  _retailerService.CreateRetailer(_retailer);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        
        [Fact]
        public async Task<bool> Testfor_Update_Retailer()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
           
            //Action
            try
            {
                retailerservice.Setup(repos => repos.UpdateRetailer(_retailerViewModel)).ReturnsAsync(_retailer); 
                var result = await  _retailerService.UpdateRetailer(_retailerViewModel);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
        
        [Fact]
        public async Task<bool> Testfor_GetRetailerById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                retailerservice.Setup(repos => repos.GetRetailerById(id)).ReturnsAsync(_retailer);
                var result = await  _retailerService.GetRetailerById(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_DeleteRetailerById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                retailerservice.Setup(repos => repos.DeleteRetailerById(id)).ReturnsAsync(response);
                var result = await  _retailerService.DeleteRetailerById(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
       
    }
}