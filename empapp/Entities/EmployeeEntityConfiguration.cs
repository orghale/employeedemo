using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace empapp.Entities
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.HasKey("Id");

            builder.HasMany(g => g.SalaryHistory)
             .WithOne(s => s.EmployeeInfo)
             .HasForeignKey(s => s.EmployeeNo);
            builder.Navigation(p => p.SalaryHistory).UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.HasMany(g => g.LeaveHistory)
             .WithOne(s => s.EmployeeInfo)
             .HasForeignKey(s => s.EmployeeNo);
            builder.Navigation(p => p.LeaveHistory).UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
