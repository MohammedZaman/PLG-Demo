using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyManagement.DBcontexts;
using CompanyManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            var x = _context.companies
           .Include(comp => comp.RestrictedCountries)
           .ThenInclude(country => country.country);
          

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(x);
           
    

            return Ok(json); 
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            var x = _context.companies
           .Where(a => a.companyId == id)
           .Include(comp => comp.RestrictedCountries)
           .ThenInclude(country => country.country);
           


            var json = Newtonsoft.Json.JsonConvert.SerializeObject(x);


            return Ok(json);
        }

        [HttpPost]
        public IActionResult AddCompany(Countries countries)
        {

            _context.addCompany(countries.companyName, countries.countries);
            _context.SaveChanges();
            return Ok(countries);


        }

        public class Countries
        {
            public string companyName { get; set; }
            public string[] countries { get; set; }
        }
    }
}
