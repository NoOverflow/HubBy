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

        public List<Activity> Get() => BackgroundQuery.GetHubActivities();

        public Activity Create(Activity project)
        {
            _activities.InsertOne(project);
            return project;
        }
    }
}
