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
        public ActionResult<IEnumerable<Measure>> GetCurrentMonth(int id)
        {
            IEnumerable<Measure> measures = _dataManager.GetApartCurrentMonth(id);
            if (measures == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(measures);
            }
        }
        [HttpGet("/LastMonth/{id}")]
        public ActionResult<IEnumerable<Measure>> GetLastMonth(int id)
        {
            IEnumerable<Measure> measures = _dataManager.GetApartLastMonth(id);
            if (measures == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(measures);
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
        public ActionResult<IEnumerable<Measure>> GetLastMonthBlock(int id)
        {
            IEnumerable<Measure> measures = _dataManager.GetBlockLastMonth(id);
            if (measures == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(measures);
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
        public ActionResult<IEnumerable<Measure>> GetAllLast()
        {
            IEnumerable<Measure> measures = _dataManager.GetAllLastMonth();
            if (measures == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(measures);
            }
        }
        [HttpGet("/CurrentPrize/{id}")]
        public IActionResult GetCurrentPrize(double id)
        {
            double measures = _dataManager.GetPrizeCurrentMonth(id);
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
