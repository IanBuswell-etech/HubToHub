using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobPusher.Services;
using JobPusher.Areas.Pusher.Models;

namespace JobPusher.Areas.Pusher.Controllers
{
    [Area("Pusher")]
    public class PusherController : Controller
    {
        private readonly IPusherService _pusherService;

        public PusherController(IPusherService pusherService)
        {
            _pusherService = pusherService;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Pusher/Create
        public ActionResult Create()
        {
            var vm = new CreateJobViewModel();
            
            return View(vm);
        }

        // POST: Pusher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateJobViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dto = viewModel.ConvertToDto();

                _pusherService.PushJob(dto);

                return Ok("Create done");
            }

            return View();
        }

        // GET: Pusher/Update/5
        public ActionResult Update(Guid id)
        {
            var vm = new UpdateJobViewModel
            {
                Id = id
            };

            return View(vm);
        }

        // POST: Pusher/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdateJobViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = vm.ConvertToDto();

                _pusherService.UpdateJob(dto);

                return Ok("Update sent");
            }

            return View(vm);
        }

        // GET: Pusher/Cancel
        public ActionResult Cancel()
        {
            var vm = new CancelJobViewModel();

            return View(vm);
        }

        // POST: Pusher/Cancel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(CancelJobViewModel vm)
        {
            try
            {
                _pusherService.CancelJob(vm.Id);
                return Ok("Delete done");
            }
            catch
            {
                return View();
            }
        }
    }
}