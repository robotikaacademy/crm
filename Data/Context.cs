using Microsoft.EntityFrameworkCore;
using crm.Data.Models;

namespace crm.Data{

    public class Context : DbContext{

        public Context():base(){}

        public DbSet<Parent> Parent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=crmDB; Integrated Security=true;");
        }

    }

}