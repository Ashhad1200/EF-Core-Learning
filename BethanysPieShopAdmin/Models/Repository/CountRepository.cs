
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopAdmin.Models.Repository
{
    public class CountRepository : ICountRepository
    {
        private readonly BethanysPieShopDbContext _context;
        public CountRepository (BethanysPieShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> AmountOfCategoriesAsync()
        {
            return await _context.Categories.CountAsync();
        }

        public async Task<int> AmountOfOrdersAsync()
        {
            return await _context.Orders.CountAsync();
        }

        public async Task<int> AmountOfPiesAsync()
        {
            return await _context.Pies.CountAsync();
        }
    }
}
