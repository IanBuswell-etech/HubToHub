using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Central.Controllers
{
    [Route("api/[controller]")]
    public class HubController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> GetHubs()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string GetHub(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void UpdateHub([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void AddHub(int id, [FromBody]string value)
        {
        }
    }
}
