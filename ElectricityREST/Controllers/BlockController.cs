using ElectricityLibrary.model;
using ElectricityREST.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        private BlockManager blockManager;
        // GET: api/<BlockController>
        [HttpGet]
        public ActionResult<IEnumerable<BlockUsage>> GetAllBlocks()
        {
            IEnumerable<BlockUsage> blocks = blockManager.GetAllBlocks();
            if (blocks == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(blocks);
            }
        }

        // GET api/<BlockController>/5
        [HttpGet("{id}")]
        
        public ActionResult GetBlockByID(int id)
        {
            try
            {
                BlockUsage block = blockManager.GetBlockUsageById(id);
                return Ok(block);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<BlockController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BlockController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlockController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
