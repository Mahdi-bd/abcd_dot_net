using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummerizedResultController : ControllerBase
    {
        private readonly ISummerizedResultService summerizedResultService;
        public SummerizedResultController(ISummerizedResultService summerizedResultService)
        {
            this.summerizedResultService = summerizedResultService;
        }

        // GET api/<SummerizedResultController>/5
        [HttpGet("{roll}")]
        public IActionResult Get(int roll)
        {
            return this.Ok(summerizedResultService.Get(roll));
        }

        // POST api/<SummerizedResultController>
        [HttpPost]
        public int Post([FromBody] SummerizedResult summerizedResult)
        {
           return summerizedResultService.Insert(summerizedResult);
        }

        // PUT api/<SummerizedResultController>/5
        [HttpPut("{roll}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SummerizedResultController>/5
        [HttpDelete("{roll}")]
        public void Delete(int roll)
        {
        }
    }
}
