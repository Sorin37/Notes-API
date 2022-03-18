using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes_API_3._1.Models;
using System;
using System.Collections.Generic;

namespace Notes_API_3._1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        static List<Owner> _owners = new List<Owner> {
            new Owner{Id = Guid.NewGuid(), Name = "Sorin"}
        };

        public OwnerController() { }
        [HttpGet]
        public IActionResult GetOwners()
        {
            return Ok(_owners);
        }
        [HttpPost]
        public IActionResult AddOwner(Owner owner)
        {
            _owners.Add(owner);
            return Ok(_owners);
        }
    }
}
