using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes_API_3._1.Models;
using System;
using System.Collections.Generic;

namespace Notes_API_3._1
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {
        static List<Owner> _owners = new List<Owner> {
            new Owner{Id = new Guid("00000000-0000-0000-0000-000000000001"), Name = "Sorin"},
            new Owner{Id = new Guid("00000000-0000-0000-0000-000000000002"), Name = "Eduard"},
            new Owner{Id = new Guid("00000000-0000-0000-0000-000000000003"), Name = "Ioan"}
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

        ///<summary>
        ///Delete an owner by id
        ///</summary>
        ///<returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            if (_owners.Find(owner => owner.Id == id) == null)
            {
                return NotFound();
            }
            _owners.Remove(_owners.Find(owner => owner.Id == id));
            return Ok(_owners);
        }

        /// <summary>
        /// Update an owner by id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
        {
            if(_owners.Find(owner => owner.Id == id) == null)
            {
                return NotFound("Owner not found");
            }
            int index = _owners.IndexOf(_owners.Find(owner => owner.Id==id));
            _owners[index] = owner;
            return Ok(_owners);
        }
    }
}
