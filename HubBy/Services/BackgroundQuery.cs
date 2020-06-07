using HubBy.Services.ApiModels;
using Leaf.xNet;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HubBy.Services
{
    /// <summary>
    /// This class is used to keep a cache of the EPITECH API
    /// </summary>
    public static class BackgroundQuery
    {
        private static object _Locker = new object();
        private const string ACTIVITY_URL = "https://intra.epitech.eu/planning/load?format=json&start={0}";
        private const int CYCLE_TIME = 5 * 60 * 1000;
        private static List<Activity> _Activities;

        public static void QueryActivityAPI()
        {
            string answer = "";

            try
            {
                using (HttpRequest request = new HttpRequest())
                {
                    request.Cookies = new CookieStorage();
                    request.UseCookies = true;
                    request.Get(Environment.GetEnvironmentVariable("AutoLoginEpitech", EnvironmentVariableTarget.User) + "/user/?format=json").ToString();
#if DEBUG
                    answer = request.Get(String.Format(ACTIVITY_URL, "2020-05-01")).ToString();
#else
                    answer = request.Get(String.Format(ACTIVITY_URL, DateTime.Now.ToString("yyyy-MM-dd"))).ToString();
#endif
                    lock (_Locker)
                        _Activities = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Activity>>(answer);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Failed to query new activities : " + ex.ToString());
            }
        }

        public static List<Activity> GetActivities()
        {
            lock (_Locker)
                return (_Activities);
        }

        public static List<Activity> GetHubActivities()
        {
            List<Activity> HubActivity = _Activities.Where(x => x.Titlemodule == "B0 - Hub").ToList();

            return (HubActivity);
        }

        public static void InitAPIBackgroundQuery()
        {
            Thread worker = new Thread(() =>
            {
                while (true)
                {
                    QueryActivityAPI();
                    Thread.Sleep(CYCLE_TIME);
                }
            });
            worker.Name = "Background Activity API Queryier";
            worker.Start();
        }
    }
}
