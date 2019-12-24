using System;
using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.DBcontexts
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options)
          : base(options)
        {
        }

        public DbSet<Country> countries { get; set; }
    }
}
