using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubBy.Database.Models
{
    public enum ActivityType
    {
        Talk,
        Workshop,
        Experimentation
    }

    public class Activity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Type")]
        public ActivityType Type { get; set; }

        [BsonElement("CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("RegisterDateLimit")]
        public DateTime RegisterDateLimit { get; set; }

        [BsonElement("Organizers")]
        public int[] Organizers;

        [BsonElement("Target")]
        public int[] Target;

        [BsonElement("Participants")]
        public int[] Participants;

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Members")]
        public int[] Members;

        [BsonElement("Duration")]
        public int Duration;

        [BsonElement("ImageURL")]
        public string ImageURL;

        [BsonElement("ParticipantsLimit")]
        public int ParticipantsLimit;
    }
}
