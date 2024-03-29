﻿using Mbenz.Trucks.Infra.Singleton;
using Microsoft.AspNetCore.Mvc;

namespace Mbenz.Trucks.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        public SingletonController(SingletonContainer singletonContainer)
        {
            SingletonContainer = singletonContainer;
        }

        public SingletonContainer SingletonContainer { get; }

        // GET api/v1/<VehiclesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return id switch
            {
                1 => Ok(SingletonContainer),
                _ => Ok(Singleton.Instance)
            };
        }
    }
}
