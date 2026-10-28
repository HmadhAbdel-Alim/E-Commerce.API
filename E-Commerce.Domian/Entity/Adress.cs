using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domian.Entity
{
    public class Adress
    {
        public Adress() { }
        public Adress(string firstName,string listName,string street, string city, string state, string zipCode, string country)
        {
            FirstName = firstName;
            ListName = listName;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }

        public string FirstName { get; set; } = string.Empty;
        public string ListName { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
