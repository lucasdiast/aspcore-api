using Microsoft.EntityFrameworkCore;
using core_api.Models;

namespace core_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DbContext> options) : base(options)
        {
            //Em bancos SQL, as connection strings ficariam aqui
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}