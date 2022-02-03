using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProjectAPI.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Assignment> Assignments { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            this.Projects.Include(project => project.ProjectManager).ToList();
            this.Assignments
                .Include(assignment => assignment.Employee)
                .Include(assignment => assignment.Project)
                .ToList();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>()
                .HasMany(employee => employee.Assignments)
                .WithOne(x => x.Employee);
            builder.Entity<Project>()
                .HasMany(project => project.Assignments)
                .WithOne(x => x.Project);
        }
    }
}
