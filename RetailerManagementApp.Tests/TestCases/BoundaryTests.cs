
using Moq;
using RetailerManagementApp.BusinessLayer.Interfaces;
using RetailerManagementApp.BusinessLayer.Services.Repository;
using RetailerManagementApp.BusinessLayer.Services;
using RetailerManagementApp.BusinessLayer.ViewModels;
using RetailerManagementApp.DataLayer;
using RetailerManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RetailerManagementApp.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly RetailerManagementAppDbContext _dbContext;

        private readonly IRetailerManagementService  _retailerService;
        public readonly Mock<IRetailerManagementRepository> retailerservice = new Mock<IRetailerManagementRepository>();

        private readonly Retailer _retailer;
        private readonly RetailerViewModel _retailerViewModel;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_RetailerName_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                retailerservice.Setup(repo => repo.CreateRetailer(_retailer)).ReturnsAsync(_retailer);
                var result = await  _retailerService.CreateRetailer(_retailer);
                var actualLength = _retailer.Name.ToString().Length;
                if (result.Name.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_RetailerAge_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                retailerservice.Setup(repo => repo.CreateRetailer(_retailer)).ReturnsAsync(_retailer);
                var result = await  _retailerService.CreateRetailer(_retailer);
                var actualLength = _retailer.Age.ToString().Length;
                if (result.Age.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_RetailerDateOfBirth_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                retailerservice.Setup(repo => repo.CreateRetailer(_retailer)).ReturnsAsync(_retailer);
                var result = await  _retailerService.CreateRetailer(_retailer);
                var actualLength = _retailer.DateOfBirth.ToString().Length;
                if (result.DateOfBirth.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_RetailerId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                retailerservice.Setup(repo => repo.CreateRetailer(_retailer)).ReturnsAsync(_retailer);
                var result = await  _retailerService.CreateRetailer(_retailer);
                var actualLength = _retailer.RetailerId.ToString().Length;
                if (result.RetailerId.ToString().Length == actualLength)
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