namespace BethanysPieShopAdmin.Models.Repository
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderDetailsAsync(int? Id);
        Task<IEnumerable<Order?>> GetAllOrderWithDetailsAsync();
    }
}
