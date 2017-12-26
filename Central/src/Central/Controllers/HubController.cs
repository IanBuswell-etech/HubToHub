using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Central.Data;
using Central.Data.Entities;
using System.Linq;

namespace Central.Controllers
{
    [Route("api/[controller]")]
    public class HubController : Controller
    {
        private readonly IDataService _dataService;

        public HubController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<HubRegistration> GetHubs()
        {
            var hubs = _dataService.GetList<HubRegistration>();
            return hubs;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult GetHub(Guid id)
        {
            var hub = _dataService.Find<HubRegistration>(x => x.Id == id).FirstOrDefault();

            return new JsonResult(hub);
        }

        // POST api/values
        [HttpPost]
        public void UpdateHub([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void AddHub(Guid id, [FromBody]string value)
        {
            var newHubRegistration = new HubRegistration
            {
                Id = id,
                IsActive = true,
                Url = value
            };
            _dataService.AddItem(newHubRegistration);
        }
    }
}
