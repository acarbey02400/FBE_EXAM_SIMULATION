using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStudentDal : EfEntityRepositoryBase<Student, SauDbContext>, IStudentDal
    {
        public List<StudentDetailDto> GetStudentDetails()
        {
            using (SauDbContext context = new SauDbContext())
            {
                var result = from st in context.Studens
                             join dp in context.Departments
                             on st.DepartmentId equals dp.Id
                             join ft in context.Faculties
                             on st.FacultyId equals ft.Id
                             join sm in context.Semesters
                             on st.SemesterId equals sm.Id
                             join yr in context.Years
                             on st.YearId equals yr.Id
                             join tp in context.TeachingOfTypes
                             on st.TeachTypeId equals tp.Id
                             join cr in context.Classroms
                             on st.ClassromId equals cr.Id
                             join od in context.Orders
                             on st.OrderId equals od.Id
                             select new StudentDetailDto
                             {
                                 ClassromName = cr.ClassromNo,
                                 DepartmentName = dp.Name,
                                 FacultyName = ft.Name,
                                 isDeleted = st.isDeleted,
                                 OrderName = od.OrderNo,
                                 SemesterName = sm.Name,
                                 StudentId = st.Id,
                                 StudentName = st.Name,
                                 StudentNumber = st.Number,
                                 StudentSurname = st.Surname,
                                 TeachTypeName = tp.Name,
                                 YearName = yr.DateTime.ToString()
                             };
                return result.ToList();
            }
        }
    }
}
