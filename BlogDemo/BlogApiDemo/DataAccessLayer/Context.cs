using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-6RH98V8;database=CoreBlogApiDb; Integrated security=true; TrustServerCertificate=True;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
