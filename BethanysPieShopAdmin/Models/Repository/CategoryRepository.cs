
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopAdmin.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        public CategoryRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }


        public IEnumerable<Category> GetAllCategory()
        {
            return _bethanysPieShopDbContext.Categories.OrderBy(p => p.CategoryId);
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _bethanysPieShopDbContext.Categories.OrderBy(c => c.CategoryId).AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _bethanysPieShopDbContext.Categories
                                .Include(p => p.Pies).AsNoTracking()
                                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            bool categoryWithTheSameNameExits = await _bethanysPieShopDbContext.Categories.AnyAsync(c => c.Name == category.Name);

            if (categoryWithTheSameNameExits)
            {
                throw new Exception("Already Exists");
            }

            _bethanysPieShopDbContext.Categories.Add(category);

            return await _bethanysPieShopDbContext.SaveChangesAsync();
        }
    }
}
