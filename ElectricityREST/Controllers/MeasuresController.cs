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
        private DataManager _dataManager;
        public MeasuresController(DataManager data)
        {
            _dataManager = data;
        }

        // GET api/<MeasuresController>/
        [HttpGet]
        public IActionResult GetAllMeasures()
        {
            List<Measure> measureList = _dataManager.GetAllMeasures();
            return Ok(measureList);
        }

        // GET api/<MeasuresController>/5
        [HttpGet("{id}")]
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
    }
}
