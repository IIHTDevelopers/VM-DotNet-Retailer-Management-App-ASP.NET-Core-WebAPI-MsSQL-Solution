using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailerManagementApp.BusinessLayer.Interfaces;
using RetailerManagementApp.BusinessLayer.ViewModels;
using RetailerManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementApp.Entities;

namespace RetailerManagementApp.Controllers
{
    [ApiController]
    public class RetailerManagementController : ControllerBase
    {
        private readonly IRetailerManagementService  _retailerService;
        public RetailerManagementController(IRetailerManagementService retailerservice)
        {
             _retailerService = retailerservice;
        }

        [HttpPost]
        [Route("create-retailer")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRetailer([FromBody] Retailer model)
        {
            var RetailerExists = await  _retailerService.GetRetailerById(model.RetailerId);
            if (RetailerExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Retailer already exists!" });
            var result = await  _retailerService.CreateRetailer(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Retailer creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Retailer created successfully!" });

        }


        [HttpPut]
        [Route("update-retailer")]
        public async Task<IActionResult> UpdateRetailer([FromBody] RetailerViewModel model)
        {
            var Retailer = await  _retailerService.UpdateRetailer(model);
            if (Retailer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Retailer With Id = {model.RetailerId} cannot be found" });
            }
            else
            {
                var result = await  _retailerService.UpdateRetailer(model);
                return Ok(new Response { Status = "Success", Message = "Retailer updated successfully!" });
            }
        }

      
        [HttpDelete]
        [Route("delete-retailer")]
        public async Task<IActionResult> DeleteRetailer(long id)
        {
            var Retailer = await  _retailerService.GetRetailerById(id);
            if (Retailer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Retailer With Id = {id} cannot be found" });
            }
            else
            {
                var result = await  _retailerService.DeleteRetailerById(id);
                return Ok(new Response { Status = "Success", Message = "Retailer deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-retailer-by-id")]
        public async Task<IActionResult> GetRetailerById(long id)
        {
            var Retailer = await  _retailerService.GetRetailerById(id);
            if (Retailer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Retailer With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(Retailer);
            }
        }

        [HttpGet]
        [Route("get-all-retailers")]
        public async Task<IEnumerable<Retailer>> GetAllRetailers()
        {
            return   _retailerService.GetAllRetailers();
        }
    }
}
