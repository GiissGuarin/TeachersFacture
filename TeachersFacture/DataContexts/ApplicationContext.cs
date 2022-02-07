using Microsoft.EntityFrameworkCore;
using TeachersFacture.Models;

namespace TeachersFacture.DataContexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            var Rol1 = new Rol() { Id = 1, Name = "Planta" };
            var Rol2 = new Rol() { Id = 2, Name = "Invitado" };

            modelbuilder.Entity<Rol>().HasData(new Rol[] { Rol1, Rol2 });

            var Course1 = new Course() { Id = 1, Name = "ISIS2601" };
            var Course2 = new Course() { Id = 2, Name = "IMEC1021" };
            var Course3 = new Course() { Id = 3, Name = "IPAT5081" };

            modelbuilder.Entity<Course>().HasData(new Course[] { Course1, Course2, Course3 });



            modelbuilder.Entity<Teacher>()
                .HasMany(c => c.Courses)
                .WithMany(t => t.Teachers)
                .UsingEntity<TeacherCourse>(
                ls => ls.HasOne(prop => prop.Courses)
                .WithMany(t => t.TeacherCourses)
                .HasForeignKey(c => c.CourseId),
                lss => lss.HasOne(prop => prop.Teachers)
                .WithMany(t => t.TeacherCourses)
                .HasForeignKey(pr => pr.TeacherId)
                );


            base.OnModelCreating(modelbuilder);
        }

        public DbSet<Teacher> TeachersInfo { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

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
