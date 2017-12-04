using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobPusher.Services;
using JobPusher.Areas.Pusher.Models;

namespace JobPusher.Areas.Test.Controllers
{
    [Area("Test")]
    public class TestController : Controller
    {
        private readonly IPusherService _pusherService;

        public TestController(IPusherService pusherService)
        {
            _pusherService = pusherService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string TestConnection()
        {
            return _pusherService.TestConnection().ToString();
        }
    }
}