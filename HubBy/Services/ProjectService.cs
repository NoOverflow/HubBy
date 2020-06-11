using HubBy.Database;
using HubBy.Database.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubBy.Services
{
    public class ProjectService
    {
        private readonly IMongoCollection<Project> _projects;

        public ProjectService(IHubbyDatabaseSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);

            _projects = database.GetCollection<Project>(settings.ProjectsCollectionName);
        }

        public List<Project> Get() => _projects.Find(x => true).ToList();

        public Project Get(string id)
        {
            bool isValidId = id.ToCharArray().Any(c => "0123456789abcdefABCDEF".Contains(c)) && id.Length == 24;

            return (isValidId ? _projects.Find(x => x.Id == id).Single() : null);
        } 

        public Task<IAsyncCursor<Project>> GetAsync() => _projects.FindAsync(x => true);

        public Task<IAsyncCursor<Project>> SearchAsync(string search) => _projects.FindAsync(x => x.Name.ToLower().Contains(search.ToLower()));

        public Project Create(Project project)
        {
            if (_projects.Find(x => project.Name == x.Name).CountDocuments() != 0)
                return (null);
            _projects.InsertOne(project);
            return (project);
        }

        public void Update(string id, Project projectIn) =>
            _projects.ReplaceOne(project => project.Id == id, projectIn);

        public void Remove(Project projectIn) =>
            _projects.DeleteOne(project => project.Id == projectIn.Id);

        public bool Remove(string ProjectName)
        {
            if (_projects.Find(x => ProjectName == x.Name).CountDocuments() == 0)
                return (false);
            _projects.DeleteOne(project => project.Name == ProjectName);
            return (true);
        }
            
    }
}
