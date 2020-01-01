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
        public DbSet<Company> companies { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CompanyCountry>()
        .HasKey(bc => new { bc.companyId, bc.countryId });
            modelBuilder.Entity<CompanyCountry>()
                .HasOne(bc => bc.company)
                .WithMany(b => b.RestrictedCountries)
                .HasForeignKey(bc => bc.companyId);
            modelBuilder.Entity<CompanyCountry>()
                .HasOne(bc => bc.country)
                .WithMany(c => c.restrictedCompanies)
                .HasForeignKey(bc => bc.countryId);
        }


    }
}
