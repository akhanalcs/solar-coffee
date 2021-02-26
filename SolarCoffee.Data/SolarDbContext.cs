using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Data
{
    //Tool to query from the database. Combination of Unit of work and Repository pattern
    public class SolarDbContext: IdentityDbContext
    {
        //DbContextOptions specifies what kind of database, connection string etc.
        public SolarDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
    }
}
