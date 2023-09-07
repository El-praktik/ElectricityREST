using ElectricityLibrary.model;
using ElectricityREST.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private CommunityManager communityManager;
        // GET: api/<CommunityController>
        [HttpGet]
        public ActionResult<IEnumerable<CommunityUsage>> GetAllMeasures()
        {
            IEnumerable<CommunityUsage> communities = communityManager.GetAllCommunityUsages();
            if (communities == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(communities);
            }
        }
        // GET api/<CommunityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommunityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CommunityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommunityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
