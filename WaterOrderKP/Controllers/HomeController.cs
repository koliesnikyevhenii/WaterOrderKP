using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WaterOrderKP.Models;

namespace WaterOrderKP.Controllers
{
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test(OrderItemModel model)
        {
            // = new OrderItem
            //{
            //    Address = "building 10 flat4",
            //    Comment = "I woild like get water in morning till 11",
            //    CountBottle = 2,
            //    Name = "Yevhenii",
            //    OrderDate = DateTime.Now,
            //    PhoneNumber = "0994285796"
            //};

         
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        

    }
}