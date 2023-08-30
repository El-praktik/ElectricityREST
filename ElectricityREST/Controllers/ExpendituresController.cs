using ElectricityLibrary.model;
using ElectricityREST.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectricityREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpendituresController : ControllerBase
    {
        private static IDataManager dtmgr = new DataManager();
        // GET: api/<ExpendituresController>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetExpendituresPerApartment(int apartmentNumber)
        {
            // TODO: Implement this
            return null;
        }
    }
}
