using Microsoft.EntityFrameworkCore;
using SMS.Models;

namespace SMS.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Student> StudentsTable { get; set; }
    }
}
