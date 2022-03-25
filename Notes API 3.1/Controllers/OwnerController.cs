using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Notes_API_3._1.Models;
using Notes_API_3._1.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes_API_3._1
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {
        IOwnerCollectionService _ownerCollectionService;
        public OwnerController(IOwnerCollectionService ownerCollectionService)
        {
            _ownerCollectionService = ownerCollectionService ?? throw new ArgumentNullException(nameof(ownerCollectionService));
        }

        ///<summary>
        ///Get all owners
        ///</summary>
        [HttpGet]
        public async Task<IActionResult> GetOwners()
        {
            return Ok(await _ownerCollectionService.GetAll());
        }

        /// <summary>
        /// Create owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddOwner([FromBody] Owner owner)
        {
            if (owner.Id == null)
            {
                owner.Id = Guid.NewGuid();
            }

            await _ownerCollectionService.Create(owner);

            return Ok(await _ownerCollectionService.GetAll());
        }

        ///<summary>
        ///Delete an owner by id
        ///</summary>
        ///<returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            if (_ownerCollectionService.Get(id) == null)
            {
                return NotFound($"No owner found with id: {id}");
            }
            await _ownerCollectionService.Delete(id);
            return Ok(await _ownerCollectionService.GetAll());
        }

        /// <summary>
        /// Update an owner by id
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] Owner owner)
        {
            if (_ownerCollectionService.Get(id) == null)
            {
                return NotFound($"No owner found with id: {id}");
            }
            await _ownerCollectionService.Update(id, owner);
            return Ok(await _ownerCollectionService.GetAll());
        }
    }
}
