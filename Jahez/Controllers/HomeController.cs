using System.Diagnostics;
using Jahez.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jahez.Controllers
{
    [Route("api/[controller]")]
    [Route("[controller]")]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public static List<object> lst { get; set; } = new List<object>()
        {
            new  { Id = 1, Name = "asd" },
            new { Id = 2, Name = "asd" },
            new  { Id = 3, Name = "asd" },

        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            if (IsJsonRequest)
            {
                return Ok(lst); 
            }

            return View(lst); 
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet("asd")]
        public IActionResult asd()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
