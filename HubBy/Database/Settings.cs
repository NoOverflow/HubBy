using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubBy.Database
{
    public class HubbyDatabaseSettings : IHubbyDatabaseSettings
    {
        public string ProjectsCollectionName { get; set; }
        public string ActivitiesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IHubbyDatabaseSettings
    {
        string ProjectsCollectionName { get; set; }
        string ActivitiesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
