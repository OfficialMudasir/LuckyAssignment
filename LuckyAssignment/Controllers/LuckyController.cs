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
 
        [HttpPost("lucky")]
        public ActionResult Post([FromBody]Lucky lucky)
        {
            

            var a = lucky.a;
            var b = lucky.b;

            var sum = a + b;
            var sub = a - b;

            var result = lucky.result;
            result = false;
            if(a == 8 || b== 8 || sum == 8 || sub == 8)
            {
                result = true;
                return Ok(result);
            }
            else if(a == 0 || b == 0)
            {
                return BadRequest("Value must not be Zero(0)");
            }
            else
            {
                return Ok(result);
            }
            
        }

        
           
        
    }
}
