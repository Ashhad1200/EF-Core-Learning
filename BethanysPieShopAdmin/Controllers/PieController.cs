using BethanysPieShopAdmin.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopAdmin.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public PieController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public async Task<IActionResult> Index()
        {
            var pie = await _pieRepository.GetAllPiesAsync();
            return View(pie);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pieDetails = await _pieRepository.GetPiesByIDAsync(id.Value);
            return View(pieDetails);
        }
    }
}
