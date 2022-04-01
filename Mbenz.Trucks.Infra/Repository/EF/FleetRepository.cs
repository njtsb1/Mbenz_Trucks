using Mbenz.Trucks.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Mbenz.Trucks.Infra.EF
{
    public class FleetRepository : IVenicleRepository
    {
        private readonly FleetContext dbContext;

        public FleetRepository(FleetContext dbContext) => this.dbContext = dbContext;
        public void Add(Venicle venicle)
        {
            dbContext.Venicles.Add(venicle);
            dbContext.SaveChanges();
        }

        public void Delete(Venicle venicle)
        {
            dbContext.Venicles.Remove(venicle);
            dbContext.SaveChanges();
        }

        public IEnumerable<Venicle> GetAll() => dbContext.Venicles.ToListAsync().Result;

        public Venicle GetById(Guid Id) => dbContext.Venicles.SingleOrDefaultAsync().Result;

        public void Update(Venicle venicle)
        {
            dbContext.Entry(venicle).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
