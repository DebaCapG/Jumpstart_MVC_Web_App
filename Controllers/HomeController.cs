using Jumpstart_MVC_Web_App.Client;
using Jumpstart_MVC_Web_App.Filters;
using Jumpstart_MVC_Web_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jumpstart_MVC_Web_App.Controllers
{
    [HttpsOnlyFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }        
        
        public IActionResult Index()
        {
            return View();
        }

        [AuthorizeActionFilter("Read")]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NotImplemented()
        {
           throw new NotImplementedException();
        }

        
        public async Task<ActionResult> Weather()
        {
           return Content(await HttpClientWrapper.GetAsync("https://localhost:7023/weatherforecast"));            
        }       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}