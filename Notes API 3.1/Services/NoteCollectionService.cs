using System;
using System.Collections.Generic;

namespace Notes_API_3._1.Services
{
    public class NoteCollectionService : INoteCollectionService
    {
        private static List<Note> _notes = new List<Note> { new Note { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
        };

        public NoteCollectionService()
        {

        }

        public bool Create(Note note)
        {
            _notes.Add(note);
            return true;
        }

        public bool Delete(Guid id)
        {
            Note note = _notes.Find(x => x.Id == id);
            if (note == null)
            {
                return false;
            }
            _notes.Remove(note);
            return true;

        }

        public Note Get(Guid id)
        {
            return _notes.Find(x => x.Id == id);
        }

        public List<Note> GetAll()
        {
            return _notes;
        }

        public List<Note> GetNotesByOwnerId(Guid ownerId)
        {
            return _notes.FindAll(x => x.OwnerId == ownerId);
        }

        public bool Update(Guid id, Note note)
        {
            Note found = _notes.Find(x => x.Id == id);
            if(found == null)
            {
                return false;
            }
            _notes[_notes.IndexOf(found)] = note;
            return true;
        }
    }
}
