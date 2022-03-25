using MongoDB.Bson;
using MongoDB.Driver;
using Notes_API_3._1.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes_API_3._1.Services
{
    public class NoteCollectionService : INoteCollectionService
    {
        private readonly IMongoCollection<Note> _notes;
        public NoteCollectionService(IMongoDBSettings mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.DatabaseName);
            _notes = database.GetCollection<Note>(mongoDBSettings.NoteCollectionName);

        }

        //private static List<Note> _notes = new List<Note> { new Note { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
        //new Note { Id = new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
        //new Note { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
        //new Note { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
        //new Note { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
        //};

        //public NoteCollectionService()
        //{

        //}

        public async Task<bool> Create(Note note)
        {
            await _notes.InsertOneAsync(note);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _notes.DeleteOneAsync(note => note.Id == id);
            if (result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;

        }

        public async Task<Note> Get(Guid id)
        {
            //var result = await _notes.FindAsync(n => n.Id == id);
            //if(result.ToList().Count == 0)
            //{
            //    return null;
            //}
            //return result.ToList()[0];
            return (await _notes.FindAsync(n => n.Id == id)).FirstOrDefault();
        }

        public async Task<List<Note>> GetAll()
        {
            var result = await _notes.FindAsync(note => true);
            return result.ToList();
        }

        public async Task<List<Note>> GetNotesByOwnerId(Guid ownerId)
        {
            return (await _notes.FindAsync(x => x.OwnerId == ownerId)).ToList();
        }

        public async Task<bool> Update(Guid id, Note note)
        {
            note.Id = id;
            var result = await _notes.ReplaceOneAsync( n => n.Id == id, note);

            if(!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _notes.InsertOneAsync(note);
                return false;
            }
            return true;
        }
    }
}
