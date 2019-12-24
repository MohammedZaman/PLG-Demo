using System;
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

        public DbSet<Company> companies { get; set; }


        public void addCompany(Company company)
        {
            companies.Add(company);
        }
    }
}
