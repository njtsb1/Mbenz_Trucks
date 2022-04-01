using System;
using System.Collections.Generic;

namespace Mbenz.Trucks.Domain
{
    public interface IVehicleRepository
    {
        void Add(Vehicle vehicle);
        void Delete(Vehicle vehicle);
        void Update(Vehicle vehicle);
        Vehicle GetById(Guid Id);
        IEnumerable<Vehicle> GetAll();
    }
}
