using DAL_SQLLite.Models;
using DAL_SQLLite.Repository;
using Microsoft.AspNetCore.Mvc;
using MoneyMind.Models;
using MoneyMind.ViewModels;
using System.Diagnostics;

namespace MoneyMind.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Spend> _spendRepo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IRepository<Spend> spendRepo)
        {
            _logger = logger;
            _spendRepo = spendRepo;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSpend(AddSpendViewModel model)
        {
            var spend = new Spend
            {
                Cost = Convert.ToDecimal(model.SpendCost),
                Category = new Category { Name = model.SpendCategory }
            };

            _spendRepo.Create(spend);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult<IEnumerable<Spend>> GetAllSpends()
        {
            var spends = _spendRepo.GetAll();
            return spends.ToList();
        }
    }
}