using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NET6Kata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        // GET: api/<SuperHeroController>
        [HttpGet]
        public async Task<ActionResult<SuperHero>> Get([FromQuery] string name = "superman", string firstName = "Alberto")
        {
            var superHero = new SuperHero
            {
                Id = 2,
                Name = name,
                FirstName = firstName,
                LastName = "Salas",
                Place = "Zaragoza"
            };

            return Ok(superHero);
        }


        // GET api/<SuperHeroController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SuperHeroController>
        /// <summary>
        /// This endpoint does this and that
        /// </summary>
        /// <param name="superHero">super hero object</param>
        /// <response status="200">Ok</response>
        /// <response status="400">Bad</response>
        [HttpPost("newRouteWithPost")]
        public async Task<ActionResult<SuperHero>> Post([FromBody] SuperHero superHero)
        {
            return Ok(superHero);
        }

        // PUT api/<SuperHeroController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuperHeroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
