using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompanyManagement.Models
{
    public class Country
    { 
        public Guid countryId { get; set; }
        public string countryName { get; set;}
   
        public virtual ICollection<CompanyCountry> restrictedCompanies { get; set; }

    }
}
