using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class SauDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@$"Server=(localdb)\MSSQLLocalDB;Database=SauExamSimulationDb;Integrated Security=true;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite; MultiSubnetFailover=False;");
        }

        public DbSet<Classrom> Classroms { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Facultiy> Faculties { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonToStudent> LessonToStudents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionToStudent> SessionToStudents { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Studens { get; set; }
        public DbSet<TeachingOfType> TeachingOfTypes { get; set; }
        public DbSet<TypeOfExam> TypeOfExams { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new FacultiyConfiguration());

        }
        public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
        {
            public void Configure(EntityTypeBuilder<Department> builder)
            {

                builder.HasOne(d => d.Facultiy)
                  .WithMany(f => f.Departments)
                  .HasForeignKey(d => d.FacultiyId)
                  .OnDelete(DeleteBehavior.Restrict);
            }
        }

        public class FacultiyConfiguration : IEntityTypeConfiguration<Facultiy>
        {
            public void Configure(EntityTypeBuilder<Facultiy> builder)
            {
                builder.ToTable("Faculties");

                builder.HasKey(f => f.Id);

                builder.Property(f => f.Name)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(f => f.isDeleted)
                       .IsRequired();

                builder.HasMany(f => f.Departments)
                       .WithOne(d => d.Facultiy)
                       .HasForeignKey(d => d.FacultiyId)
                       .OnDelete(DeleteBehavior.SetNull);



            }
        }
        public void ConfigureDepartment(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(d => d.isDeleted)
                   .IsRequired();

            builder.HasOne(d => d.Facultiy)
                   .WithMany(f => f.Departments)
                   .HasForeignKey(d => d.FacultiyId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
