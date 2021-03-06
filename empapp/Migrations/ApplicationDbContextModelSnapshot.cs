// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using empapp.Infrastructure;

namespace empapp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("empapp.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datecreated");

                    b.Property<string>("DateEmployed")
                        .HasColumnType("text")
                        .HasColumnName("dateemployed");

                    b.Property<string>("Department")
                        .HasColumnType("text")
                        .HasColumnName("department");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dob");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("EmployeeNo")
                        .HasColumnType("text")
                        .HasColumnName("employeeno");

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("fullname");

                    b.Property<string>("Gender")
                        .HasColumnType("text")
                        .HasColumnName("gender");

                    b.Property<string>("Mobile")
                        .HasColumnType("text")
                        .HasColumnName("mobile");

                    b.Property<DateTime>("ResumptionDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("resumptiondate");

                    b.Property<string>("Status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_employees");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("empapp.Entities.LeaveOfAbsence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datecreated");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int?>("EmployeeInfoId")
                        .HasColumnType("integer")
                        .HasColumnName("employeeinfoid");

                    b.Property<string>("EmployeeNo")
                        .HasColumnType("text")
                        .HasColumnName("employeeno");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("enddate");

                    b.Property<string>("LeaveType")
                        .HasColumnType("text")
                        .HasColumnName("leavetype");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("startdate");

                    b.HasKey("Id")
                        .HasName("pk_leaveofabsences");

                    b.HasIndex("EmployeeInfoId")
                        .HasDatabaseName("ix_leaveofabsences_employeeinfoid");

                    b.ToTable("leaveofabsences");
                });

            modelBuilder.Entity("empapp.Entities.Salaries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision")
                        .HasColumnName("amount");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("createdby");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datecreated");

                    b.Property<int?>("EmployeeInfoId")
                        .HasColumnType("integer")
                        .HasColumnName("employeeinfoid");

                    b.Property<string>("EmployeeNo")
                        .HasColumnType("text")
                        .HasColumnName("employeeno");

                    b.Property<DateTime?>("Enddate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("enddate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("isactive");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("startdate");

                    b.HasKey("Id")
                        .HasName("pk_salaries");

                    b.HasIndex("EmployeeInfoId")
                        .HasDatabaseName("ix_salaries_employeeinfoid");

                    b.ToTable("salaries");
                });

            modelBuilder.Entity("empapp.Entities.LeaveOfAbsence", b =>
                {
                    b.HasOne("empapp.Entities.Employee", "EmployeeInfo")
                        .WithMany("LeaveHistory")
                        .HasForeignKey("EmployeeInfoId")
                        .HasConstraintName("fk_leaveofabsences_employees_employeeinfoid");

                    b.Navigation("EmployeeInfo");
                });

            modelBuilder.Entity("empapp.Entities.Salaries", b =>
                {
                    b.HasOne("empapp.Entities.Employee", "EmployeeInfo")
                        .WithMany("SalaryHistory")
                        .HasForeignKey("EmployeeInfoId")
                        .HasConstraintName("fk_salaries_employees_employeeinfoid");

                    b.Navigation("EmployeeInfo");
                });

            modelBuilder.Entity("empapp.Entities.Employee", b =>
                {
                    b.Navigation("LeaveHistory");

                    b.Navigation("SalaryHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
