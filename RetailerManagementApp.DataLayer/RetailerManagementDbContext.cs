using Microsoft.EntityFrameworkCore;
using RetailerManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetailerManagementApp.DataLayer
{
    public class RetailerManagementAppDbContext : DbContext
    {
        public RetailerManagementAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Retailer> Retailers { get; set; }
    }

}