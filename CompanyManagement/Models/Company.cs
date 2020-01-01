using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompanyManagement.Models
{
    public class Company
    {

      
        public Guid companyId { get; set; }
        public string companyName { get; set; }
        
        public virtual ICollection<CompanyCountry> RestrictedCountries { get; set; }

    }
}
