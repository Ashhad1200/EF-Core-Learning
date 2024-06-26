
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

        public async Task<int> AddPieAsync(Pie pie)
        {
            _context.Pies.Add(pie);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pie>> GetAllPiesAsync()
        {

            return await _context.Pies.OrderByDescending(p => p.Price).AsNoTracking().ToListAsync();

        }

        public async Task<Pie?> GetPiesByIDAsync(int id)
        {
            return await _context.Pies.Include(i => i.Ingredients).Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(p => p.PieId == id);
        }
    }
}
