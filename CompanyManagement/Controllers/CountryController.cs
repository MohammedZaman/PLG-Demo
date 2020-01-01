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
    public class CountryController : ControllerBase
    {


        private readonly ILogger<CountryController> _logger;
        private readonly CompanyContext _context;

        public CountryController(ILogger<CountryController> logger, CompanyContext context)
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
            var x = _context.countries
           .Include(comp => comp.restrictedCompanies)
           .ThenInclude(company => company.company);
         

            
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(x);



            return Ok(json);
        }


    }
}
