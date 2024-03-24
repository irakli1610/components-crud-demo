using Microsoft.EntityFrameworkCore;
using JunkWebApi.Models;

namespace JunkWebApi.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : 
            base(dbContextOptions)
        {
            
        }
        public DbSet<Component> component {  get; set; }
        
    }
}
