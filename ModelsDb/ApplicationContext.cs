using Microsoft.EntityFrameworkCore;

namespace ModelsDb
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }        

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ProducerCustomerExam;Trusted_Connection=True;");
        }
    }
}
