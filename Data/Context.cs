using Microsoft.EntityFrameworkCore;
using crm.Data.Models;

namespace crm.Data{

    public class Context : DbContext{

        public Context():base(){}

        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Child_Parents> Child_Parents { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course_Teacher> Course_Teachers { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=crmDB; Integrated Security=true;");
        }

    }

}