namespace BethanysPieShopAdmin.Models.Repository
{
    public interface ICountRepository
    {
        Task<int> AmountOfPiesAsync();
        Task<int> AmountOfCategoriesAsync();
        Task<int> AmountOfOrdersAsync();

    }
}
