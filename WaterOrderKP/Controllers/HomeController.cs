using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Diagnostics;
using WaterOrderKP.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using static NuGet.Packaging.PackagingConstants;


namespace WaterOrderKP.Controllers
{
    public class HomeController : Controller
    {
        public static List<HomeworkModel> countries = new List<HomeworkModel>();

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

        public IActionResult Test(OrderItem model)
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

       

        [HttpGet]
        public IActionResult Homework()
        {
            string fileName = "countryFile.json";
            var path = Path.Combine(Environment.CurrentDirectory, fileName);
            string json = System.IO.File.ReadAllText(path);
            countries = JsonSerializer.Deserialize<HomeworkModel[]>(json).ToList();
            return View(countries[1]);
        }
        public ActionResult GetCapital(string country)
        {
            var capital = countries.FirstOrDefault(x => x.country == country);
            //var g = capital.city;
            return View("~/Views/Partials/CountryDetailes.cshtml", capital);
        }
        public HomeworkModel GetCapital2(string country)
        {
            var capital = countries.FirstOrDefault(x => x.country == country);
            //var g = capital.city;
            return capital;
        }
        public List<string> CountryCity(string term)
        {
            List<string> countryList = new List<string>();
            //countryList = countries.Where(a => a.country.Contains(term))
            //                .Select(a => new { value = a.Model })
            //                .Distinct();
            countryList = countries.Where(record => record.country.Contains(term))
                                  .Select(x => x.country).ToList();

            return countryList;
        }


    }
}