namespace BethanysPieShopAdmin.Models.Repository
{
    public interface ICategoryRepository
    {

        IEnumerable<Category> GetAllCategory();
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<int> AddCategoryAsync(Category category);         
    }
}
