using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ASP.NET_MVC_CRUD.Models
{
    public partial class DBModels : DbContext
    {
        public DBModels()
            : base("name=DBModels")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Office)
                .IsUnicode(false);
        }
    }
}
