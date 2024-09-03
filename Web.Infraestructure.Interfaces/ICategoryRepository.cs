using Web.Domain.Entities;

namespace Web.Infraestructure.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Categories>> GetAllCategories();
    }
}
