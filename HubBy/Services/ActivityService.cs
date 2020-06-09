using HubBy.Database;
using HubBy.Database.Models;
using HubBy.Services.ApiModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubBy.Services
{
    public class ActivityService
    {
        private readonly IMongoCollection<Activity> _activities;

        public ActivityService(IHubbyDatabaseSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);

            _activities = database.GetCollection<Activity>(settings.ActivitiesCollectionName);
        }

        public List<Activity> Get()
        {
            var holder = BackgroundQuery.GetHubActivities();

            holder.AddRange(GetOwn());
            return (holder);
        }

        public List<Activity> GetOwn() => _activities.Find(x => true).ToList();

        public Activity GetOwn(string id) => _activities.Find(x => x.Codeacti == id).Single();

        public Activity Get(string actId) 
        {
            var entry = BackgroundQuery.GetHubActivities().Find(x => x.Codeacti == actId);

            if (entry == null)
                entry = GetOwn(actId);
            return (entry);
        }

        public bool Delete(string codeActi)
        {
            var res = _activities.DeleteOne(x => x.Codeacti == codeActi);

            if (!res.IsAcknowledged || res.DeletedCount == 0)
                return (false);
            return (true);
        }

        public Activity Create(Activity project)
        {
            if (_activities.Find(x => x.ActiTitle == project.ActiTitle || project.Codeacti == x.Codeacti).CountDocuments() != 0)
                return (null);
            _activities.InsertOne(project);
            return (project);
        }
    }
}
