using LuckyAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace LuckyAssignment.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Lucky lucky)
        {
            
            Lucky luck = new Lucky();
            using(var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(lucky), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:44328/api/Lucky/lucky", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lucky.result = Convert.ToBoolean(apiResponse);
                    // luck = JsonConvert.DeserializeObject<Lucky>(apiResponse);
                }
            }
            


            return View(lucky);
        }
    }
}
