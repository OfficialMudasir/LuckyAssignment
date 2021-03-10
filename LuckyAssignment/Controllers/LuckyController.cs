using LuckyAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuckyAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuckyController : ControllerBase
    {
        // GET: api/<LuckyController>
        [HttpGet]
        public ActionResult Get(Lucky lucky)
        {
            //these var's are just for test purpose
            var a = 10;
            var b = 8;

            //var a = lucky.a;
            //var b = lucky.b;

            var sum = a + b;
            var sub = a - b;
            if(a == 8 || b== 8 || sum == 8 || sub == 8)
            {
                return Ok(true);
            }
            else if(a == 0 || b == 0)
            {
                return BadRequest("Value must not be Zero(0)");
            }
            else
            {
                return Ok(false);
            }
            
        }

        
        [HttpPost]
        public ActionResult Post(Lucky lucky)
        {
            
            if(lucky.a == 0 || lucky.b == 0)
            {
                return BadRequest("Value must not be zero(0)");
            }
            else
            {
                return Ok(lucky.result);
            }
            
        }
           
        
    }
}
