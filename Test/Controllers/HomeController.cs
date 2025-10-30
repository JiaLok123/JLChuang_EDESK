using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Test.Data;
using Test.Models;

namespace Test.Controllers
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

        [HttpGet]
        public JsonResult GetCustomers(string country = null, string city = null, string pincode = null)
        {
            var items = CustomerRepository.GetAll();

            if (!string.IsNullOrEmpty(country))
                items = items.Where(c => c.Country == country);

            if (!string.IsNullOrEmpty(city))
                items = items.Where(c => c.City == city);

            if (!string.IsNullOrEmpty(pincode))
                items = items.Where(c => c.PinCode == pincode);

            // Example: order by name
            var result = items.OrderBy(c => c.Id);

            return Json(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var customer = CustomerRepository.GetById(id);
            if (customer == null)
                return NotFound();

            // Return JSON
            return Json(customer);
        }

        [HttpGet]
        public JsonResult GetTreeData()
        {
            var data = CustomerRepository.GetAll()
                .GroupBy(c => c.Country)
                .Select(g => new
                {
                    country = g.Key,
                    cities = g.GroupBy(c => c.City)
                              .Select(cg => new
                              {
                                  city = cg.Key,
                                  pinCodes = cg.Select(c => c.PinCode).Distinct().ToArray()
                              }).ToArray()
                })
                .ToList();

            return Json(data);
        }


        public IActionResult Privacy()
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
