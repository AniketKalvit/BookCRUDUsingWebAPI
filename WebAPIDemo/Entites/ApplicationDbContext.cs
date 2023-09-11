using Microsoft.EntityFrameworkCore;

namespace WebAPIDemo.Entites
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
