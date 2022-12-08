using LearningApplication.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;

namespace LearningApplication.Controllers
{
    public class ValuesController : Controller
    {
        /// <summary>
        /// Method to fetch the API data and passing to View
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ValuesModel values = new ValuesModel();
            using (var client = new HttpClient())        // Installed System.Net.Http from Nuget packages
            {                
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
                //HTTP API GET
                var responseTask = client.GetAsync("values");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string readTask = result.Content.ReadAsStringAsync().Result; // Reading API data
                    values.MyString = JsonConvert.DeserializeObject<string>(readTask); //Installed Newtonsoft.Json from Nuget packages  
                                                                                      // Converting JSON to string
                }
            }
            return View(model: values); // passing data to view
        }
    }
}