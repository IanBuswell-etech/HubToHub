using System;
using Microsoft.AspNetCore.Mvc;
using MiniHub.Services;
using MiniHub.Api.Models;

namespace MiniHub.Api.Controllers
{
    [Route("api/[controller]")]
    public class FirmController : Controller
    {
        private readonly IFirmService _firmService;

        public FirmController(IFirmService firmService)
        {
            _firmService = firmService;
        }
        
        [HttpGet]
        public string Index()
        {
            return "Index!";
        }

        [HttpGet("GetViaId/{id}")]
        public JsonResult GetViaId(Guid id)
        {
            var firm = _firmService.GetViaId(id);

            return new JsonResult(firm);
        }

        [HttpGet("GetAllFirms")]
        public JsonResult GetAllJobs()
        {
            var firm = _firmService.GetAll();

            return new JsonResult(firm);
        }

        // POST api/values
        [HttpPost("Create")]
        public void Create([FromBody]CreateFirmModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = model.ConvertToDto();
                
                _firmService.CreateNew(dto);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _firmService.Delete(id);
        }
    }
}
