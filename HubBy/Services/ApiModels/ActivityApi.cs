using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubBy.Services.ApiModels
{
    
    public class Activity
    {
        [JsonProperty("scolaryear", NullValueHandling = NullValueHandling.Ignore)]
        public long? Scolaryear { get; set; }

        [JsonProperty("codemodule", NullValueHandling = NullValueHandling.Ignore)]
        public string Codemodule { get; set; }

        [JsonProperty("codeinstance", NullValueHandling = NullValueHandling.Ignore)]
        public string? Codeinstance { get; set; }

        [JsonProperty("codeacti", NullValueHandling = NullValueHandling.Ignore)]
        public string Codeacti { get; set; }

        [JsonProperty("codeevent", NullValueHandling = NullValueHandling.Ignore)]
        public string Codeevent { get; set; }

        [JsonProperty("semester", NullValueHandling = NullValueHandling.Ignore)]
        public long? Semester { get; set; }

        [JsonProperty("instance_location", NullValueHandling = NullValueHandling.Ignore)]
        public string? InstanceLocation { get; set; }

        [JsonProperty("titlemodule", NullValueHandling = NullValueHandling.Ignore)]
        public string Titlemodule { get; set; }

        [JsonProperty("prof_inst")]
        public ProfInst[] ProfInst { get; set; }

        [JsonProperty("acti_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ActiTitle { get; set; }

        [JsonProperty("num_event", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumEvent { get; set; }

        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Start { get; set; }

        [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? End { get; set; }

        [JsonProperty("total_students_registered", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalStudentsRegistered { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type_title", NullValueHandling = NullValueHandling.Ignore)]
        public string? TypeTitle { get; set; }

        [JsonProperty("is_rdv", NullValueHandling = NullValueHandling.Ignore)]
        public long? IsRdv { get; set; }

        [JsonProperty("nb_hours", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? NbHours { get; set; }

        [JsonProperty("allowed_planning_start", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? AllowedPlanningStart { get; set; }

        [JsonProperty("allowed_planning_end", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? AllowedPlanningEnd { get; set; }

        [JsonProperty("nb_group", NullValueHandling = NullValueHandling.Ignore)]
        public long? NbGroup { get; set; }

        [JsonProperty("nb_max_students_projet")]
        public long? NbMaxStudentsProjet { get; set; }

        [JsonProperty("room")]
        public Room Room { get; set; }

        [JsonProperty("dates")]
        public object Dates { get; set; }

        [JsonProperty("module_available", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ModuleAvailable { get; set; }

        [JsonProperty("module_registered", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ModuleRegistered { get; set; }

        [JsonProperty("past", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Past { get; set; }

        [JsonProperty("allow_register", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowRegister { get; set; }

        [JsonProperty("event_registered", NullValueHandling = NullValueHandling.Ignore)]
        public EventRegistered? EventRegistered { get; set; }

        [JsonProperty("display", NullValueHandling = NullValueHandling.Ignore)]
        public long? Display { get; set; }

        [JsonProperty("project", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Project { get; set; }

        [JsonProperty("rdv_group_registered")]
        public string RdvGroupRegistered { get; set; }

        [JsonProperty("rdv_indiv_registered")]
        public string RdvIndivRegistered { get; set; }

        [JsonProperty("allow_token", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowToken { get; set; }

        [JsonProperty("register_student", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RegisterStudent { get; set; }

        [JsonProperty("register_prof", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RegisterProf { get; set; }

        [JsonProperty("register_month", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RegisterMonth { get; set; }

        [JsonProperty("in_more_than_one_month", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InMoreThanOneMonth { get; set; }
    }

    public partial class ProfInst
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string? Type { get; set; }

        [JsonProperty("login", NullValueHandling = NullValueHandling.Ignore)]
        public string? Login { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        [JsonProperty("picture", NullValueHandling = NullValueHandling.Ignore)]
        public string? Picture { get; set; }
    }

    public partial class Room
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string? Code { get; set; }

        [JsonProperty("seats", NullValueHandling = NullValueHandling.Ignore)]
        public long? Seats { get; set; }
    }

    public partial struct EventRegistered
    {
        public bool? Bool;
        public string String;

        public static implicit operator EventRegistered(bool Bool) => new EventRegistered { Bool = Bool };
        public static implicit operator EventRegistered(string String) => new EventRegistered { String = String };
    }
}
