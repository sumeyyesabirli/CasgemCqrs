using Microsoft.EntityFrameworkCore;

namespace CasgemCqrs.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SUM;initial catalog=CqrsDesignPattern;integrated security=true");
        }

        public DbSet<Product> Products { get; set; }
    }
}
