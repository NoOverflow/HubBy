using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubBy.Database.Models
{
    public enum ProjectState
    {
        Free,
        Wip,
        Recruiting,
        Done
    }

    public class Project
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("State")]
        public ProjectState State { get; set; }

        [BsonElement("CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Members")]
        public int[] Members { get; set; }

        [BsonElement("ImageURL")]
        public string ImageURL { get; set; }

    }
}
