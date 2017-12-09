using Microsoft.AspNetCore.Mvc;

namespace Central.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        // GET api/values/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }
    }
}