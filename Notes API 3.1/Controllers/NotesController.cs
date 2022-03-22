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
        private static List<Note> _notes = new List<Note> { new Note { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
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

        /// <summary>
        /// Get notes by owner id
        /// </summary>
        [HttpGet("{ownerId}")]
        public IActionResult GetNotesByOwnerId(Guid ownerId)
        {
            return Ok(_notes.Where(x => x.OwnerId == ownerId).ToList());
        }

        /// <summary>
        /// Get note by id
        /// </summary>
        [HttpGet("/Note/{noteId}", Name = "GetNote")]
        public IActionResult GetNotesById(Guid noteId)
        {
            foreach (var note in _notes)
            {
                if (note.Id == noteId)
                    return Ok(note);
            }
            return NotFound();
        }

        /// <summary>
        /// Add a note
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateNote([FromBody] Note note)
        {
            if (note == null)
                return BadRequest("Note is null");
            _notes.Add(note);
            return Ok(_notes);
        }

        [HttpPost("/actionresult")]
        public ActionResult<Note> CreateNote2(Note note)
        {
            _notes.Add(note);
            return CreatedAtRoute("GetNote", new { id = note.Id.ToString() }, note);
        }

        //[HttpPut]
        //public IActionResult Post([FromBody] Note note)
        //{
        //    //_notes.Add(note);
        //    return Ok(note);
        //}

        [HttpPut("{id}")]
        public IActionResult UpdateNote(Guid id, [FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note can't be null");
            }

            int index = _notes.FindIndex(n => n.Id == id);
            if (index == -1)
            {
                return CreateNote(note);
            }
            note.Id = id;
            _notes[index] = note;

            return Ok(_notes);
        }

        [HttpPut("{noteId}/{ownerId}")]
        public IActionResult UpdateNoteByNoteAndOwnerId(Guid noteId, Guid ownerId, [FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note can't be null");
            }

            int index = _notes.FindIndex(n => n.Id == noteId && n.OwnerId == ownerId);
            if (index == -1)
            {
                return CreateNote(note);
            }
            _notes[index] = note;

            return Ok(_notes);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(Guid id)
        {
            if (_notes.Find(n => n.Id == id) == null)
            {
                return NotFound("No note found with that id");
            }

            _notes.Remove(_notes.Find(n => n.Id == id));
            return Ok(_notes);
        }

        [HttpDelete("{noteId}/{ownerId}")]
        public IActionResult DeleteNoteByNoteAndOwnerId(Guid noteId, Guid ownerId)
        {
            if (_notes.Find(n => n.Id == noteId && n.OwnerId == ownerId) == null)
            {
                return NotFound("No note found with those ids");
            }

            _notes.Remove(_notes.Find(n => n.Id == noteId && n.OwnerId == ownerId));
            return Ok(_notes);
        }

        [HttpDelete("AllOf{ownerId}")]
        public IActionResult DeleteNotesOfOwnerId(Guid ownerId)
        {
            if (_notes.Find(n => n.OwnerId == ownerId) == null)
            {
                return NotFound("No note found with this id");
            }

            _notes.RemoveAll(n => n.OwnerId == ownerId);
            return Ok(_notes);
        }
    }

}
