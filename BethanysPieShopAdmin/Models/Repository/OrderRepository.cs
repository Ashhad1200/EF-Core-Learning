
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopAdmin.Models.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BethanysPieShopDbContext _context;
        public OrderRepository (BethanysPieShopDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order?>> GetAllOrderWithDetailsAsync()
        {
            return await _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Pie).OrderByDescending(o => o.OrderId).ToListAsync();
        }

        public async Task<Order?> GetOrderDetailsAsync(int? Id)
        {
            if (Id != null)
            {
                var order = await _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Pie).OrderByDescending(o => o.OrderId).Where(o => o.OrderId == Id.Value).FirstOrDefaultAsync();

                return order;
            }

            return null;
        }
    }
}
