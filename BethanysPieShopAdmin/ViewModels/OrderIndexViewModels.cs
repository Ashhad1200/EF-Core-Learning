using BethanysPieShopAdmin.Models;

namespace BethanysPieShopAdmin.ViewModels
{
    public class OrderIndexViewModels
    {
        public IEnumerable<Order?> Orders { get; set; }
        public IEnumerable<OrderDetail?> OrderDetails { get; set; }
        public IEnumerable<Pie?> pies { get; set; }
        public int? SelectedOrderId { get; set; }
        public int? SelectedOrderDetailId { get; set; }
    }
}
