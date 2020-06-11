using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubBy.Services.ApiModels
{
    
    public class Activity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("scolaryear")]
        [JsonProperty("scolaryear", NullValueHandling = NullValueHandling.Ignore)]
        public long? Scolaryear { get; set; }

        [BsonElement("codemodule")]
        [JsonProperty("codemodule", NullValueHandling = NullValueHandling.Ignore)]
        public string Codemodule { get; set; }

        [BsonElement("codeinstance")]
        [JsonProperty("codeinstance", NullValueHandling = NullValueHandling.Ignore)]
        public string? Codeinstance { get; set; }

        [BsonElement("codeacti")]
        [JsonProperty("codeacti", NullValueHandling = NullValueHandling.Ignore)]
        public string Codeacti { get; set; }

        [BsonElement("codeevent")]
        [JsonProperty("codeevent", NullValueHandling = NullValueHandling.Ignore)]
        public string Codeevent { get; set; }

        [BsonElement("semester")]
        [JsonProperty("semester", NullValueHandling = NullValueHandling.Ignore)]
        public long? Semester { get; set; }

        [BsonElement("instance_location")]
        [JsonProperty("instance_location", NullValueHandling = NullValueHandling.Ignore)]
        public string? InstanceLocation { get; set; }

        [BsonElement("titlemodule")]
        [JsonProperty("titlemodule", NullValueHandling = NullValueHandling.Ignore)]
        public string Titlemodule { get; set; }

        [BsonElement("acti_title")]
        [JsonProperty("acti_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ActiTitle { get; set; }

        [BsonElement("num_event")]
        [JsonProperty("num_event", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumEvent { get; set; }

        [BsonElement("start")]
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Start { get; set; }

        [BsonElement("end")]
        [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? End { get; set; }

        [BsonElement("total_students_registered")]
        [JsonProperty("total_students_registered", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalStudentsRegistered { get; set; }

        [BsonElement("title")]
        [JsonProperty("title")]
        public string Title { get; set; }

        [BsonElement("type_title")]
        [JsonProperty("type_title", NullValueHandling = NullValueHandling.Ignore)]
        public string? TypeTitle { get; set; }

        [BsonElement("is_rdv")]
        [JsonProperty("is_rdv", NullValueHandling = NullValueHandling.Ignore)]
        public long? IsRdv { get; set; }

        [BsonElement("nb_hours")]
        [JsonProperty("nb_hours", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? NbHours { get; set; }

        [BsonElement("allowed_planning_start")]
        [JsonProperty("allowed_planning_start", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? AllowedPlanningStart { get; set; }

        [BsonElement("allowed_planning_end")]
        [JsonProperty("allowed_planning_end", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? AllowedPlanningEnd { get; set; }

        [BsonElement("nb_group")]
        [JsonProperty("nb_group", NullValueHandling = NullValueHandling.Ignore)]
        public long? NbGroup { get; set; }

        [BsonElement("nb_max_students_projet")]
        [JsonProperty("nb_max_students_projet")]
        public long? NbMaxStudentsProjet { get; set; }

        [BsonElement("room")]
        [JsonProperty("room")]
        public Room Room { get; set; }

        [BsonElement("dates")]
        [JsonProperty("dates")]
        public object Dates { get; set; }

        [BsonElement("module_available")]
        [JsonProperty("module_available", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ModuleAvailable { get; set; }

        [BsonElement("module_registered")]
        [JsonProperty("module_registered", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ModuleRegistered { get; set; }

        [BsonElement("past")]
        [JsonProperty("past", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Past { get; set; }

        [BsonElement("allow_register")]
        [JsonProperty("allow_register", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowRegister { get; set; }

        [BsonElement("display")]
        [JsonProperty("display", NullValueHandling = NullValueHandling.Ignore)]
        public long? Display { get; set; }

        [BsonElement("project")]
        [JsonProperty("project", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Project { get; set; }

        [BsonElement("rdv_group_registered")]
        [JsonProperty("rdv_group_registered")]
        public string RdvGroupRegistered { get; set; }

        [BsonElement("rdv_indiv_registered")]
        [JsonProperty("rdv_indiv_registered")]
        public string RdvIndivRegistered { get; set; }

        [BsonElement("allow_token")]
        [JsonProperty("allow_token", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowToken { get; set; }

        [BsonElement("register_student")]
        [JsonProperty("register_student", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RegisterStudent { get; set; }

        [BsonElement("register_prof")]
        [JsonProperty("register_prof", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RegisterProf { get; set; }

        [BsonElement("register_month")]
        [JsonProperty("register_month", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RegisterMonth { get; set; }

        [BsonElement("in_more_than_one_month")]
        [JsonProperty("in_more_than_one_month", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InMoreThanOneMonth { get; set; }
    }

    public partial class Room
    {
        [BsonElement("type")]
        [JsonProperty("type")]
        public string? Type { get; set; }

        [BsonElement("code")]
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string? Code { get; set; }

        [BsonElement("seats")]
        [JsonProperty("seats", NullValueHandling = NullValueHandling.Ignore)]
        public long? Seats { get; set; }
    }
}
