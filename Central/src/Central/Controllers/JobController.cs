﻿using System.Collections.Generic;
using Central.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Central.Controllers
{
    [Route("api/[controller]")]
    public class JobController : Controller
    {
        JobService _jobService;

        public JobController(JobService jobService)
        {
            _jobService = jobService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}