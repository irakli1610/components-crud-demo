using JunkWebApi.Models;

namespace JunkWebApi.Interfaces
{
    public interface IComponentRepository
    {
        Task<List<Component>> GetAllAsync();

        Task<Component?> GetByIdAsync(int id);

        Task<Component> CreateAsync(Component componentModel);

        Task<Component?> DeleteAsync(int id);

        Task<Component?> UpdateAsync(int id, Component componentModel);
    }
}
