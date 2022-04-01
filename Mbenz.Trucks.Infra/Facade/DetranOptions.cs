using System;

namespace Mbenz.Trucks.Infra.Facade
{
    public class DetranOptions
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string BaseUrl { get; set; }
        public string InspectionUri { get; set; }
        public int QuantityDaysToSchedule { get; set; }
    }
}
