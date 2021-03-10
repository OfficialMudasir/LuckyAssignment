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
                StringContent content = new StringContent(JsonConvert.SerializeObject(luck), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("localhost:44328/api/Lucky", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    luck = JsonConvert.DeserializeObject<Lucky>(apiResponse);
                }
            }
            
            return View(luck);
        }
    }
}
