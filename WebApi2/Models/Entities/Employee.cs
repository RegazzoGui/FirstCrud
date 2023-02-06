using System;

namespace WebApi2.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }

        public DateTime BirthDate { get; set; }

        public string MaritalState { get; set; }

        public string Gender { get; set; }

        public string AddressLine { get; set; }

        public string City { get; set; }
        public string CountryRegionCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public string PostalCode { get; set; }
    }
}
