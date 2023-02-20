using Microsoft.EntityFrameworkCore;

namespace StudentProject.Models
{
    public class HRContext : DbContext
    {
        public HRContext()
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
        }
    }
}
