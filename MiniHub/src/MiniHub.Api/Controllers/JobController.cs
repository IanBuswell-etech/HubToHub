using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniHub.Services;
using MiniHub.Api.Models;

namespace MiniHub.Api.Controllers
{
    [Route("api/[controller]")]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        
        [HttpGet]
        public string Index()
        {
            return "Index!";
        }

        [HttpGet("GetJobViaId/{id}")]
        public JsonResult GetJobViaId(Guid id)
        {
            var job = _jobService.GetJobViaId(id);

            return new JsonResult(job);
        }

        [HttpGet("GetViaJobReference/{reference}")]
        public JsonResult GetJobViaRef(string reference)
        {
            var job = _jobService.GetJobViaReference(reference);

            return new JsonResult(job);
        }

        [HttpGet("GetAllJobs")]
        public JsonResult GetAllJobs()
        {
            var job = _jobService.GetAllJobs();

            return new JsonResult(job);
        }

        // POST api/values
        [HttpPost("Create")]
        public void Create([FromBody]CreateJobModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = model.ConvertToDto();
                
                _jobService.CreateNewJob(dto);
            }
        }

        [HttpPost("CreateJob")]
        public void CreateJob([FromBody]CreateRequest model)
        {
            if (ModelState.IsValid)
            {
                var dto = model.Job.ConvertToDto();

                _jobService.CreateNewJob(dto);
            }
        }

        [HttpPost("AllocateJob")]
        public StatusCodeResult AllocateJob(Guid jobId, Guid? firmId)
        {
            if (_jobService.AllocateJob(jobId, firmId))
            {
                return Ok();
            };
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _jobService.DeleteJob(id);
        }
    }
}
