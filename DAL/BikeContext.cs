using BIKE_SHOWROOM_MANAGEMENT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIKE_SHOWROOM_MANAGEMENT.DAL
{
    public class BikeContext: DbContext
    {

        public BikeContext(DbContextOptions<BikeContext> options) : base(options)
        {

        }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<BIKE_SHOWROOM_MANAGEMENT.Models.BikeViewModel> BikeViewModel { get; set; }

       public DbSet<Login> Users { get; set; }
       public DbSet<BIKE_SHOWROOM_MANAGEMENT.Models.LoginViewModel> LoginViewModel { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<BIKE_SHOWROOM_MANAGEMENT.Models.EmployeeViewModel> EmployeeViewModel { get; set; }
    }
}
