using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyManagement.DBcontexts;
using CompanyManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
  

        private readonly ILogger<CompanyController> _logger;
        private readonly CompanyContext _context;

        public CompanyController(ILogger<CompanyController> logger, CompanyContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> companies = _context.companies.ToList();
            return Ok(companies);
        }

        [HttpPost]
        public IActionResult AddCompany(Company company)
        {

            _context.addCompany(company);
            _context.SaveChanges();
            return Ok(company);


        }
    }
}
