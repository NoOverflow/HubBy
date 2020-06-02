using HubBy.Database;
using HubBy.Database.Models;
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

        public List<Activity> Get() => _activities.Find(x => true).ToList();

        public Activity Get(string id) => _activities.Find(x => x.Id == id).Single();

        public Activity Create(Activity project)
        {
            _activities.InsertOne(project);
            return project;
        }

        public void Update(string id, Activity activityIn) =>
            _activities.ReplaceOne(activity => activity.Id == id, activityIn);

        public void Remove(Activity activityIn) =>
            _activities.DeleteOne(activity => activity.Id == activityIn.Id);

        public DeleteResult Remove(string id) =>
            _activities.DeleteOne(activity => activity.Id == id);

        public DeleteResult RemoveName(string name) =>
             _activities.DeleteOne(activity => activity.Name == name);
    }
}
