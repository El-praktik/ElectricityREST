using ElectricityLibrary.model;
using ElectricityREST.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasuresController : ControllerBase
    {
        private static IDataManager dtmgr = new DataManager();

        // GET api/<MeasuresController>/
        [HttpGet]
        public IActionResult GetAllMeasures()
        {
            List<Measure> measureList = dtmgr.GetAllMeasures();
            return Ok(measureList);
        }

        // GET api/<MeasuresController>/5
        [HttpGet("{id}")]
        public IActionResult GetMeasureById(int measureId)
        {
            try
            {
                Measure measure = dtmgr.GetMeasureById(measureId);
                return Ok(measure);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
    }
}
