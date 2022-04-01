using Mbenz.Trucks.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mbenz.Trucks.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesRepository repository;
        private readonly IVehicleDetran vehicleDetran;

        public VehiclesController(IVehicleRepository repository, IVehicleDetran vehicleDetran)
        {
            this.repository = repository;
            this.vehicleDetran = vehicleDetran;
        }
        // GET: api/<VehiclesController>
        [HttpGet]
        public IActionResult Get() => Ok(repository.GetAll());

        // GET api/<VehiclesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var vehicle = repository.GetById(id);
            if (vehicle == null)
                return NotFound();
            return Ok(vehicle);
        }

        // POST api/<VehiclesController>
        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            repository.Add(vehicle);
            return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicle);
        }

        // PUT api/<VehiclesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] vehicle vehicle)
        {
            repository.Update(vehicle);

            return NoContent();
        }

        // PUT api/<VehiclesController>/5
        [HttpPut("{id}/inspection")]
        public IActionResult Put(Guid id)
        {
            vehicleDetran.ScheduleInspectionDetran(id);

            return NoContent();
        }

        // DELETE api/<VehiclesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var vehicle = repository.GetById(id);
            if (vehicle == null)
                return NotFound();

            repository.Delete(vehicle);

            return NoContent();
        }
    }
}
