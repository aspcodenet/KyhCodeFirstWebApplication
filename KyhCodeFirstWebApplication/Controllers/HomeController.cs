using KyhCodeFirstWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KyhCodeFirstWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //Hämta från AdsApi
            string url = _configuration.GetValue<string>("AdsApi:Url");
            int antalPoster = _configuration.GetValue<int>("AdsApi:AntalPoster"); ;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}