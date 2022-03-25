using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes_API_3._1.Services
{
    public interface INoteCollectionService : ICollectionService<Note>
    {
        Task<List<Note>> GetNotesByOwnerId(Guid ownerId);
    }
}
