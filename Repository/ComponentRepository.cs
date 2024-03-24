using JunkWebApi.Data;
using JunkWebApi.Interfaces;
using JunkWebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace JunkWebApi.Repository
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly ApplicationDbContext _context;

        public ComponentRepository( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Component> CreateAsync(Component componentModel)
        {
            await _context.component.AddAsync(componentModel);
            await _context.SaveChangesAsync();
            return componentModel;
        }

        public async Task<Component?> DeleteAsync(int id)
        {
            var componentModel = await _context.component.FirstOrDefaultAsync(x => x.Id == id);
            if (componentModel == null)
            {
                return null;
            }
            _context.component.Remove(componentModel);
            await _context.SaveChangesAsync();  
            return componentModel;
        }

        public  async Task<List<Component>> GetAllAsync()
        {
            return await  _context.component.ToListAsync();
            
        }

        public async Task<Component?> GetByIdAsync(int id)
        {
            return await _context.component.FindAsync(id);
        }

        public async Task<Component?> UpdateAsync(int id, Component componentModel)
        {
            var existingComponent = await _context.component.FindAsync(id);
            if (existingComponent == null)
            {
                return null;
            }
            existingComponent.Name= componentModel.Name;
            existingComponent.Status= componentModel.Status;
            existingComponent.Id= id;
            existingComponent.Quantity= componentModel.Quantity;

            await _context.SaveChangesAsync();
            return existingComponent;
        }
    }
}
