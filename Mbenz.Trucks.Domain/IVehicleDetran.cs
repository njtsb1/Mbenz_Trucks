using System;
using System.Threading.Tasks;

namespace Mbenz.Trucks.Domain
{
    public interface IVehicleDetran
    {
        public Task ScheduleInspectionDetran(Guid vehicleId);
    }
}
