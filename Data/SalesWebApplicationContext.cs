using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebApplication.Models;

namespace SalesWebApplication.Data
{
    public class SalesWebApplicationContext : DbContext
    {
        public SalesWebApplicationContext (DbContextOptions<SalesWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebApplication.Models.Department> Department { get; set; } = default!;
    }
}
