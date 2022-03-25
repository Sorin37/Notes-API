using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Notes_API_3._1.Models
{
    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
