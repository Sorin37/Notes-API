using System;
using System.Collections.Generic;

namespace Notes_API_3._1.Services
{
    public interface INoteCollectionService : ICollectionService<Note>
    {
        List<Note> GetNotesByOwnerId(Guid ownerId);
    }
}
