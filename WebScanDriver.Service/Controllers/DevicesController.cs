using System.Web.Http;

namespace WebScanDriver.Service.Controllers
{
    public class DevicesController : ApiController
    {
        [HttpGet]
        [Route("api/Devices")]
        public IHttpActionResult Get()
        {
            return Ok("Hello from TopShelf Web API (.NET Framework)!");
        }
    }
}
