using empapp.Entities;
using Microsoft.EntityFrameworkCore;

namespace empapp.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Salaries> Salaries { get; set; }
        public virtual DbSet<LeaveOfAbsence> LeaveOfAbsences { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLowerCaseNamingConvention();
    }
}
