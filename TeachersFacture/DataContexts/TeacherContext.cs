using Microsoft.EntityFrameworkCore;
using TeachersFacture.Models;

namespace TeachersFacture.DataContexts
{
    public class TeacherContext : DbContext
    {
        public TeacherContext(DbContextOptions<TeacherContext> options): base(options)
        {
        }

        public DbSet<Teacher> TeachersInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();



            var connectionString = configuration.GetConnectionString("ConexionTest");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
