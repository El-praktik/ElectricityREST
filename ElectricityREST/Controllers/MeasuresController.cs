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

        // GET api/<MeasuresController>/5
        [HttpGet("{id:int}")]
        public IActionResult GetMeasureById(int measureId)
        {
            try
            {
                Measure measure = _dataManager.GetMeasureById(measureId);
                return Ok(measure);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
        // GET api/<MeasuresController>/5
        //[HttpGet("{id:int}")]
        //public IActionResult GetApartmentsInBlock(int blockId)
        //{
        //    try
        //    {
        //        List<BlockUsage> _blocks = _dataManager.GetApartmentsInBlock(blockId);
        //        return Ok(_blocks);
        //    }
        //    catch (Exception)
        //    {
        //        return NotFound();
        //    }
        //}
    }
}
