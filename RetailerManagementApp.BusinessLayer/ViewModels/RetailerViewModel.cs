using System;
using System.Collections.Generic;
using System.Text;

namespace RetailerManagementApp.BusinessLayer.ViewModels
{
    public class RetailerViewModel
    {
        public int RetailerId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
