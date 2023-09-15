using ElectricityLibrary.model;
using ElectricityREST.InterFaces;
using ElectricityREST.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolarController : ControllerBase
    {
        private SolarManager _solarManager;
        public SolarController(ELDBContext _context)
        {
            _solarManager = new SolarManager(_context);
        }
        [HttpGet("/AllSolarCurrent")]
        public ActionResult<IEnumerable<Solar>> GetAllCurrent()
        {
            IEnumerable<Solar> measures = _solarManager.GetAllCurrentMonth();
            if (measures == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(measures);
            }
        }
        [HttpGet("/AllSolarLast")]
        public ActionResult<IEnumerable<Solar>> GetAllLast()
        {
            IEnumerable<Solar> measures = _solarManager.GetAllLastMonth();
            if (measures == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(measures);
            }
        }
    }
}
