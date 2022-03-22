using Notes_API_3._1.Models;
using System;
using System.Collections.Generic;

namespace Notes_API_3._1.Services
{
    public class OwnerCollectionService : IOwnerCollectionService
    {
        static List<Owner> _owners = new List<Owner> {
            new Owner{Id = new Guid("00000000-0000-0000-0000-000000000001"), Name = "Sorin"},
            new Owner{Id = new Guid("00000000-0000-0000-0000-000000000002"), Name = "Eduard"},
            new Owner{Id = new Guid("00000000-0000-0000-0000-000000000003"), Name = "Ioan"}
        };

        public bool Create(Owner owner)
        {
            _owners.Add(owner);
            return true;
        }

        public bool Delete(Guid id)
        {

            if (_owners.Find(x => x.Id == id) == null)
            {
                return false;
            }
            _owners.Remove(_owners.Find(x => x.Id == id));
            return true;
        }

        public Owner Get(Guid id)
        {
            Owner owner = _owners.Find(x => x.Id == id);
            return owner;
        }

        public List<Owner> GetAll()
        {
            return _owners;
        }

        public bool Update(Guid id, Owner owner)
        {
            if (_owners.Find(o => o.Id == id) == null)
            {
                return false;
            }
            _owners[_owners.FindIndex(o => o.Id == id)] = owner;
            return true;
        }
    }
}
