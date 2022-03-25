using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Notes_API_3._1.Models;
using System.Linq;
using Notes_API_3._1.Services;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Notes_API_3._1
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {


        INoteCollectionService _noteCollectionService;

        public NotesController(INoteCollectionService noteCollectionService)
        {
            _noteCollectionService = noteCollectionService ?? throw new ArgumentNullException(nameof(noteCollectionService));
        }


        /// <summary>
        /// Get all notes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            return Ok(await _noteCollectionService.GetAll());
        }

        /////// <summary>
        /////// Get notes by owner id
        /////// </summary>
        ////[HttpGet("{ownerId}")]
        ////public IActionResult GetNotesByOwnerId(Guid ownerId)
        ////{
        ////    return Ok(_notes.Where(x => x.OwnerId == ownerId).ToList());
        ////}

        ///// <summary>
        ///// Get note by id
        ///// </summary>
        //[HttpGet("/Note/{noteId}", Name = "GetNote")]
        //public IActionResult GetNotesById(Guid noteId)
        //{
        //    var result = _noteCollectionService.Get(noteId);
        //    if (result == null)
        //    {
        //        return NotFound($"No note found with id {noteId}");
        //    }
        //    return Ok(result);
        //}

        /// <summary>
        /// Get note by id
        /// </summary>
        [HttpGet("{noteId}")]
        public async Task<IActionResult> GetNotesById(Guid noteId)
        {
            var result = await _noteCollectionService.Get(noteId);
            if (result == null)
            {
                return NotFound($"No note found with id {noteId}");
            }
            return Ok(result);
        }

        ///// <summary>
        ///// Get notes by owner id
        ///// </summary>
        //[HttpGet("/owner/{ownerId}")]
        //public IActionResult GetNotesByOwnerId(Guid ownerId)
        //{
        //    return Ok(_noteCollectionService.GetNotesByOwnerId(ownerId));
        //}

        /// <summary>
        /// Add a note
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] Note note)
        {
            if (note == null)
                return BadRequest("Note is null");
            if(note.Id == null)
            {
                note.Id = Guid.NewGuid();
            }
            await _noteCollectionService.Create(note);
            return Ok(await _noteCollectionService.GetAll());
        }

        ////[HttpPost("/actionresult")]
        ////public ActionResult<Note> CreateNote2(Note note)
        ////{
        ////    _notes.Add(note);
        ////    return CreatedAtRoute("GetNote", new { id = note.Id.ToString() }, note);
        ////}

        //////[HttpPut]
        //////public IActionResult Post([FromBody] Note note)
        //////{
        //////    //_notes.Add(note);
        //////    return Ok(note);
        //////}

        /// <summary>
        /// Update note
        /// </summary>
        /// <param name="id"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(Guid id, [FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note can't be null");
            }

            if(await _noteCollectionService.Get(id) == null)
            {
                await _noteCollectionService.Create(note);
                return Ok("Note with this id was not found but got created now");
            }

            await _noteCollectionService.Update(id, note);

            return Ok(await _noteCollectionService.GetAll());
        }

        ////[HttpPut("{noteId}/{ownerId}")]
        ////public IActionResult UpdateNoteByNoteAndOwnerId(Guid noteId, Guid ownerId, [FromBody] Note note)
        ////{
        ////    if (note == null)
        ////    {
        ////        return BadRequest("Note can't be null");
        ////    }

        ////    int index = _notes.FindIndex(n => n.Id == noteId && n.OwnerId == ownerId);
        ////    if (index == -1)
        ////    {
        ////        return CreateNote(note);
        ////    }
        ////    _notes[index] = note;

        ////    return Ok(_notes);
        ////}

        /// <summary>
        /// Delete note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            if (await _noteCollectionService.Delete(id) == false)
            {
                return NotFound($"No note found with id {id}");
            }
            return Ok(await _noteCollectionService.GetAll());
        }

        ////[HttpDelete("{noteId}/{ownerId}")]
        ////public IActionResult DeleteNoteByNoteAndOwnerId(Guid noteId, Guid ownerId)
        ////{
        ////    if (_notes.Find(n => n.Id == noteId && n.OwnerId == ownerId) == null)
        ////    {
        ////        return NotFound("No note found with those ids");
        ////    }

        ////    _notes.Remove(_notes.Find(n => n.Id == noteId && n.OwnerId == ownerId));
        ////    return Ok(_notes);
        ////}

        ////[HttpDelete("AllOf{ownerId}")]
        ////public IActionResult DeleteNotesOfOwnerId(Guid ownerId)
        ////{
        ////    if (_notes.Find(n => n.OwnerId == ownerId) == null)
        ////    {
        ////        return NotFound("No note found with this id");
        ////    }

        ////    _notes.RemoveAll(n => n.OwnerId == ownerId);
        ////    return Ok(_notes);
        ////}
    }

}
