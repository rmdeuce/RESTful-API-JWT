using Microsoft.EntityFrameworkCore;
using ReastApiJwt.Models;

namespace ReastApiJwt.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Todo>Todos { get; set; }
    }
}