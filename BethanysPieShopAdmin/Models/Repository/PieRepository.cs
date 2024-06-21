
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopAdmin.Models.Repository
{
    public class PieRepository : IPieRepository
    {

        private readonly BethanysPieShopDbContext _context;

        public PieRepository(BethanysPieShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pie>> GetAllPiesAsync()
        {

            return await _context.Pies.OrderByDescending(p => p.Price).ToListAsync();
            
        }

        public async Task<Pie?> GetPiesByIDAsync(int id)
        {
            return await _context.Pies.Include(i => i.Ingredients).Include(c => c.Category).FirstOrDefaultAsync(p => p.PieId == id);
        }
    }
}
