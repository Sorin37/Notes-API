using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes_API_3._1.Models;
using Notes_API_3._1.Services;
using System;
using System.Collections.Generic;

namespace Notes_API_3._1
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {
        IOwnerCollectionService _ownerCollectionService;
        public OwnerController(IOwnerCollectionService ownerCollectionService) {
            _ownerCollectionService = ownerCollectionService ?? throw new ArgumentNullException(nameof(ownerCollectionService));
        }

        ///<summary>
        ///Get all owners
        ///</summary>
        [HttpGet]
        public IActionResult GetOwners()
        {
            return Ok(_ownerCollectionService.GetAll());
        }

        /// <summary>
        /// Create owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddOwner(Owner owner)
        {
            _ownerCollectionService.Create(owner);
            return Ok(_ownerCollectionService.GetAll());
        }

        ///<summary>
        ///Delete an owner by id
        ///</summary>
        ///<returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            if (_ownerCollectionService.Get(id) == null)
            {
                return NotFound($"No owner found with id: {id}");
            }
            _ownerCollectionService.Delete(id);
            return Ok(_ownerCollectionService.GetAll());
        }

        /// <summary>
        /// Update an owner by id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody] Owner owner)
        {
            if (_ownerCollectionService.Get(id) == null)
            {
                return NotFound($"No owner found with id: {id}");
            }
            _ownerCollectionService.Update(id, owner);
            return Ok(_ownerCollectionService.GetAll());
        }
    }
}
