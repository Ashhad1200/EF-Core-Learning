using Microsoft.AspNetCore.Mvc.Rendering;
using BethanysPieShopAdmin.Models;
namespace BethanysPieShopAdmin.ViewModels
{
    public class PieAddViewModel
    {
        public IEnumerable<SelectListItem>? Catagories { get; set; } = default!;
        public Pie? Pie { get; set; }
    }
}
