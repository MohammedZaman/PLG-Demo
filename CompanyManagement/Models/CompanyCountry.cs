using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CompanyManagement.Models
{
    public class CompanyCountry
    {
        [ForeignKey("Country")]
        public Guid countryId { get; set; }
        public Country country { get; set; }

        [ForeignKey("Company")]
        public Guid companyId { get; set; }
        
        public Company company{ get; set; }
    }
}
