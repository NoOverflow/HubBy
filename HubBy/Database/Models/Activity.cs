using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
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
        [BsonRepresentation(BsonType.String)]
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [BsonElement("Type")]
        [BsonRepresentation(BsonType.String)]
        public ActivityType Type { get; set; }

        [BsonElement("CreatedOn")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [BsonElement("RegisterDateLimit")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime RegisterDateLimit { get; set; }

        [BsonElement("Organizers")]
        public int[] Organizers;

        [BsonElement("Target")]
        public int[] Target;

        [BsonElement("Duration")]
        [BsonRepresentation(BsonType.Int32)]
        public int Duration;

        [BsonElement("Participants")]
        public List<int> Participants;

        [BsonElement("ImageURL")]
        [BsonRepresentation(BsonType.String)]
        public string ImageURL;

        [BsonElement("Description")]
        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [BsonElement("ParticipantsLimit")]
        [BsonRepresentation(BsonType.Int32)]
        public int ParticipantsLimit;
    }
}
