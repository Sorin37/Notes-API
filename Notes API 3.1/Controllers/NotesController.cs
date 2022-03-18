using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Notes_API_3._1.Models;
using System.Linq;

namespace Notes_API_3._1
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        static List<Note> _notes = new List<Note> {
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "First Note", Description = "First Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Second Note", Description = "Second Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Third Note", Description = "Third Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Fifth Note", Description = "Fifth Note Description" }
        };


        public NotesController() { }


        /// <summary>
        /// Get all notes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_notes);
        }

        [HttpGet("{ownerId}")]
        /// <summary>
        /// Get notes by owner id
        /// </summary>
        public IActionResult GetNotesByOwnerId(Guid ownerId)
        {
            return Ok(_notes.Where(x => x.OwnerId == ownerId).ToList());
        }

        [HttpGet("/Note/{noteId}")]
        /// <summary>
        /// Get note by id
        /// </summary>
        public IActionResult GetNotesById(Guid noteId)
        {
            foreach (var note in _notes)
            {
                if (note.Id == noteId)
                    return Ok(note);
            }
            return NotFound();
        }

        [HttpPost]
        /// <summary>
        /// Add a note
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateNote([FromBody] Note note)
        {
            _notes.Add(note);
            return Ok(_notes);
        }

        //[HttpPost("/actionResult")]
        //public ActionResult<Note> CreateNote2([FromBody] Note note)
        //{
        //    _notes.Add(note);
        //    return CreatedAtRoute("Notes", new {id = note.Id.ToString()}, note);
        //}

        [HttpPut]
        public IActionResult Post([FromBody] Note note)
        {
            return Ok(note);
        }
    }

}
