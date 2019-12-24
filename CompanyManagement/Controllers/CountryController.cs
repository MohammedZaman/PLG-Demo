﻿using System;
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
    public class CountryController : ControllerBase
    {


        private readonly ILogger<CountryController> _logger;
        private readonly CountryContext _context;

        public CountryController(ILogger<CountryController> logger, CountryContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Country> companies = _context.countries.ToList();
            return Ok(companies);
        }


    }
}
