using ElectricityLibrary.model;
using ElectricityREST.InterFaces;
using ElectricityREST.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasuresController : ControllerBase
    {
        private IDataManager _dataManager;
        public MeasuresController(ELDBContext _context)
        {
            _dataManager = new DataManager(_context);
        }

        // GET api/<MeasuresController>/
        [HttpGet]
        public ActionResult<IEnumerable<Measure>> GetAllMeasures()
        {
            IEnumerable<Measure> measures = _dataManager.GetAllMeasures();
            if(measures == null) 
            {
                return NoContent();
            }
            else
            {
                return Ok(measures);
            }
        }
        [HttpGet("/CurrentMonth/{id}")]
        public IActionResult GetCurrentMonth(int id)
        {
            IEnumerable<Measure> measures = _dataManager.GetApartCurrentMonth(id);
            double sum = 0;
            foreach(Measure measure in measures)
            {
                sum += measure.PowerUsed;
            }
            if (measures == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(sum);
            }
        }
        [HttpGet("/LastMonth/{id}")]
        public IActionResult GetLastMonth(int id)
        {
            IEnumerable<Measure> measures = _dataManager.GetApartLastMonth(id);
            double sum = 0;
            foreach (Measure measure in measures)
            {
                sum += measure.PowerUsed;
            }
            if (measures == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(sum);
            }
        }
        [HttpGet("/CurrentMonthBlock/{id}")]
        public ActionResult<IEnumerable<Measure>> GetCurrentMonthBlock(int id)
        {
            IEnumerable<Measure> measures = _dataManager.GetBlockCurrentMonth(id);
            if (measures == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(measures);
            }
        }
        [HttpGet("/LastMonthBlock/{id}")]
        public IActionResult GetLastMonthBlock(int id)
        {
            IEnumerable<Measure> measures = _dataManager.GetBlockLastMonth(id);
            double sum = 0;
            foreach (Measure measure in measures)
            {
                sum += measure.PowerUsed;
            }
            if (measures == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(sum);
            }
        }
        [HttpGet("/AllCurrent")]
        public ActionResult<IEnumerable<Measure>> GetAllCurrent()
        {
            IEnumerable<Measure> measures = _dataManager.GetAllCurrentMonth();
            if (measures == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(measures);
            }
        }
        [HttpGet("/AllLast")]
        public IActionResult GetAllLast()
        {
            IEnumerable<Measure> measures = _dataManager.GetAllLastMonth();
            double sum = 0;
            foreach (Measure measure in measures)
            {
                sum += measure.PowerUsed;
            }
            if (measures == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(sum);
            }
        }
        [HttpGet("/CurrentPrize/{id}&&{monthDiff}")]
        public IActionResult GetCurrentPrize(double id, int monthDiff)
        {
            double measures = _dataManager.GetPrizeCurrentMonth(id, monthDiff);
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
