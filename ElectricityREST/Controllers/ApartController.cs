using ElectricityLibrary.model;
using ElectricityREST.InterFaces;
using ElectricityREST.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartController : ControllerBase
    {
        private ApartManager _apartManager;

        public ApartController(ELDBContext _context)
        {
            _apartManager = new ApartManager(_context);
        }

        // GET: api/<ApartController>
        [HttpGet]
            public ActionResult<IEnumerable<ApartUsage>> GetAllAparts()
            {
                IEnumerable<ApartUsage> aparts = _apartManager.GetAllAparts();
                if (aparts == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(aparts);
                }
            }
        

        // GET api/<ApartController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ApartUsage>> GetCurrentMonth(int id)
        {
            IEnumerable<ApartUsage> aparts = _apartManager.GetApartCurrentMonth(id);
            if (aparts == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(aparts);
            }
        }

        // POST api/<ApartController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
