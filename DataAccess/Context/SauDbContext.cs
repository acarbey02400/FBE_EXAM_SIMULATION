using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class SauDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SauExamSimulationDb;Trusted_Connection=true");
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

    }
}
