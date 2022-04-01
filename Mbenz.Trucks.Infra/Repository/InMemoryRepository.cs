using Mbenz.Trucks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mbenz.Trucks.Infra.Repository
{
    public class InMemoryRepository : IVehicleRepository
    {
        private readonly IList<Vehicle> entities = new List<Vehicle>();
        public void Add(Vehicle vehicle)
        {
            entities.Add(vehicle);
        }

        public void Delete(Vehicle vehicle) => entities.Remove(vehicle);

        public IEnumerable<Vehicle> GetAll() => entities.ToList();

        public Vehicle GetById(Guid Id) => entities.SingleOrDefault(c => c.Id == Id);

        public void Update(Vehicle vehicle)
        {
            entities.Remove(GetById(vehicle.Id));
            entities.Add(vehicle);
        }
    }
}
