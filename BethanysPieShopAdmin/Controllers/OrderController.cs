using BethanysPieShopAdmin.Models;
using BethanysPieShopAdmin.Models.Repository;
using BethanysPieShopAdmin.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopAdmin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController (IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IActionResult> Index(int? orderId , int? orderDetailId)
        {
            OrderIndexViewModels orderIndexViewModels = new()
            {
                Orders = await _orderRepository.GetAllOrderWithDetailsAsync()
            };

            if (orderId != null)
            {
                Order selectedOrderDetails = orderIndexViewModels.Orders.Where(op => op.OrderId == orderId).Single();
                orderIndexViewModels.OrderDetails = selectedOrderDetails.OrderDetails;
                orderIndexViewModels.SelectedOrderDetailId = orderId;
            }
            if(orderDetailId != null)
            {
                var selectedOrderDetailId = orderIndexViewModels.OrderDetails.Where(op => op.OrderDetailId == orderDetailId).Single();
                orderIndexViewModels.pies = new List<Pie>() { selectedOrderDetailId.Pie };
                orderIndexViewModels.SelectedOrderDetailId = orderDetailId;
            }
            return View(orderIndexViewModels);
        }
    }
}
