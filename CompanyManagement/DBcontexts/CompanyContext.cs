using System;
using System.Collections.Generic;
using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.DBcontexts
{
    public class CompanyContext : DbContext
    {

        public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
        {
            
        }

        public DbSet<Country> countries { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<CompanyCountry> companyCountries{ get; set; }

        public void addCompany(string companyS, string[] countries)
        {
            var company = new Company
            {
                companyName = companyS,

            };


            for (int i = 0; i < countries.Length; i++) {
                var country = new Country { countryName = countries[i] };
               
                CompanyCountry cc = new CompanyCountry { companyId = company.companyId, company = company, countryId = country.countryId, country = country };
                companyCountries.Add(cc);
                
            }
        }

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
