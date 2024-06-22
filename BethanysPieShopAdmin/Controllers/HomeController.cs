using BethanysPieShopAdmin.Models;
using BethanysPieShopAdmin.Models.Repository;
using BethanysPieShopAdmin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BethanysPieShopAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountRepository _countRepository;

        public HomeController(ICountRepository countRepository)
        {
            _countRepository = countRepository;
        }

        public async Task<IActionResult> Index()
        {
            CountViewModel countViewModel = new()
            {
                CountOfPies = await _countRepository.AmountOfPiesAsync(),
                CountOfCategory = await _countRepository.AmountOfCategoriesAsync(),
                CountOfOrders = await _countRepository.AmountOfOrdersAsync(),
            };

            return View(countViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
