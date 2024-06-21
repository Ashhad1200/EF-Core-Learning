namespace BethanysPieShopAdmin.Models.Repository
{
    public interface IPieRepository
    {
        Task<IEnumerable<Pie>> GetAllPiesAsync();
        Task <Pie?> GetPiesByIDAsync(int id);
    }
}
