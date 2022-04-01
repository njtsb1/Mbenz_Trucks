using System;

namespace Mbenz.Trucks.Domain
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string YearofManufacture { get; set; }
    }
}
