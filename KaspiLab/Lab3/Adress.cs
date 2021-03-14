using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Adress
    {
        public string Country { get; private set; }

        public string District { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }

        public string HouseNumber { get; private set; }

        public Adress(string country, string district, string city, string street, string houseNumber)
        {
            Country = country;
            District = district;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"Адресс: {Country}, {District}, {City}, {Street}, {HouseNumber}";
        }

    }
}
