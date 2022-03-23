using MongoDB.Bson;
using MongoDB.Driver;
using Notes_API_3._1.Models;
using Notes_API_3._1.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes_API_3._1.Services
{
    public class OwnerCollectionService : IOwnerCollectionService
    {
        private readonly IMongoCollection<Owner> _owners;
        public OwnerCollectionService(IMongoDBSettings mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.ConnectionString);
            var database = client.GetDatabase(mongoDBSettings.DatabaseName);
            _owners = database.GetCollection<Owner>(mongoDBSettings.OwnerCollectionName);

        }

        //public bool Create(Owner owner)
        //{
        //    _owners.Add(owner);
        //    return true;
        //}

        //public bool Delete(Guid id)
        //{

        //    if (_owners.Find(x => x.Id == id) == null)
        //    {
        //        return false;
        //    }
        //    _owners.Remove(_owners.Find(x => x.Id == id));
        //    return true;
        //}

        //public Owner Get(Guid id)
        //{
        //    Owner owner = _owners.Find(x => x.Id == id);
        //    return owner;
        //}

        //public bool Update(Guid id, Owner owner)
        //{
        //    if (_owners.Find(o => o.Id == id) == null)
        //    {
        //        return false;
        //    }
        //    _owners[_owners.FindIndex(o => o.Id == id)] = owner;
        //    return true;
        //}
        public async Task<bool> Create(Owner owner)
        {
            await _owners.InsertOneAsync(owner);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _owners.DeleteOneAsync(x => x.Id == id);
            if (result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<Owner> Get(Guid id)
        {
            return (await _owners.FindAsync(n => n.Id == id)).FirstOrDefault();
        }

        public async Task<List<Owner>> GetAll()
        {

            return (await _owners.FindAsync(owner => true)).ToList();
        }

        public async Task<bool> Update(Guid id, Owner owner)
        {
            if(Get(id) == null)
            {
                return false;
            }
            owner.Id = id;
            await _owners.ReplaceOneAsync(x => x.Id == id, owner);
            return true;
        }

    }
}
