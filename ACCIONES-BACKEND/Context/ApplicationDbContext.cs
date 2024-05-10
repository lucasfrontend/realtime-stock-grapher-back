using ACCIONES_BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace ACCIONES_BACKEND.Context
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    { 
    
    }

    public DbSet<User> Users { get; set; }
    //public DbSet<User> Users => Set<User>();
    public DbSet<UserFavorite> UserFavorites { get; set; }
  }
}
