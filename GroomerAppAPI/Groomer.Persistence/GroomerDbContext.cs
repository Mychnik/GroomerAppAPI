using Groomer.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Persistence
{
  public  class GroomerDbContext : IdentityDbContext
    {
        public GroomerDbContext(DbContextOptions<GroomerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pet> Pets  { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Visit>  Vists{ get; set; }

    }
}
 