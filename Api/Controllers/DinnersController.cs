using Microsoft.AspNetCore.Mvc;


namespace BuberDinner.Api.Controllers
{
    [Route("[controller]")]
    public class DinnersController : ApiController
    {
        // GET: Dinners
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Array.Empty<string>());
        }

        // GET api/<DinnersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DinnersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DinnersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DinnersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
