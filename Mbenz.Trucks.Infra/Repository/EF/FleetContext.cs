using Mbenz.Trucks.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mbenz.Trucks.Infra.EF
{
    public class FleetContext : DbContext
    {
        public FleetContext(DbContextOptions<FleetContext> options)
           : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
