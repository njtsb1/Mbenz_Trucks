using Mbenz.Trucks.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Mbenz.Trucks.Infra.EF
{
    public class FleetRepository : IVehicleRepository
    {
        private readonly FleetContext dbContext;

        public FleetRepository(FleetContext dbContext) => this.dbContext = dbContext;
        public void Add(Vehicle vehicle)
        {
            dbContext.Vehicles.Add(vehicle);
            dbContext.SaveChanges();
        }

        public void Delete(Vehicle vehicle)
        {
            dbContext.Vehicles.Remove(vehicle);
            dbContext.SaveChanges();
        }

        public IEnumerable<Vehicle> GetAll() => dbContext.Vehicles.ToListAsync().Result;

        public Vehicle GetById(Guid Id) => dbContext.Vehicles.SingleOrDefaultAsync().Result;

        public void Update(Vehicle vehicle)
        {
            dbContext.Entry(vehicle).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
