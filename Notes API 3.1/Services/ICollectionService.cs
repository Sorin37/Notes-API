using System;
using System.Collections.Generic;

namespace Notes_API_3._1.Services
{
    public interface ICollectionService<T>
    {
        List<T> GetAll();

        T Get(Guid id);

        bool Create(T model);

        bool Update(Guid id, T model);

        bool Delete(Guid id);

    }
}
