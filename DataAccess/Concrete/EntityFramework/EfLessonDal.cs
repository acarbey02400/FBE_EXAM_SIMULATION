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
    public class EfLessonDal : EfEntityRepositoryBase<Lesson, SauDbContext>, ILessonDal
    {
        
        public List<LessonDetailDto> GetLessonDetails()
        {
            using (SauDbContext context = new SauDbContext())
            {
                var result = from p in context.Lessons
                             join d in context.Departments
                             on p.DepartmentId equals d.Id
                             join s in context.Staffs
                             on p.StaffId equals s.Id
                             join se in context.Semesters
                             on p.SemesterId equals se.Id
                             join y in context.Years
                             on p.YearId equals y.Id
                             join t in context.TypeOfExams
                             on p.TypeExamId equals t.Id
                             join e in context.Exams
                             on p.ExamId equals e.Id
                             join ses in context.Sessions
                             on p.SessionId equals ses.Id
                             select new LessonDetailDto
                             {
                                 DepartmentName = d.Name,
                                 ExamDateTime = p.ExamDateTime,
                                 ExamName = e.Name,
                                 isDeleted = p.isDeleted,
                                 LessonCode = p.LessonCode,
                                 LessonId = p.Id,
                                 LessonName = p.Name,
                                 SemesterName = se.Name,
                                 SessionName = ses.Name,
                                 StaffName = s.Name,
                                 TypeExamName = t.Name,
                                 YearName = y.DateTime.ToString()
                             };
                              return result.ToList();
            }
        }
    }
}
