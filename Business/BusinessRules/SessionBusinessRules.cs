using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class SessionBusinessRules
    {
        private readonly IlessonToStudentService _lessonToStudentService;
        private readonly IStudentService _studentService;

        public SessionBusinessRules(IlessonToStudentService lessonToStudentService,  IStudentService studentService)
        {
            _lessonToStudentService = lessonToStudentService;
            _studentService = studentService;
        }

        public int CheckSessionTime(List<Lesson> lessons)
        {
            var lessonToStudentList=new List<LessonToStudent>();
            
            foreach (var lesson in lessons)
            {
                lessonToStudentList.AddRange(_lessonToStudentService.getByLessonId(lesson.Id).Data);
            }
            var studentId = lessonToStudentList.Select(x => x.StudentId).Distinct().ToList();
            var students = _studentService.getAll().Data.Where(x => studentId.Contains(x.Id));
            var lessonTimes = lessons.ToDictionary(lesson => lesson.Id, lesson => lesson.LessonTime);
            var maxLessonTime = students.Max(student =>
                lessonToStudentList.Where(lts => lts.StudentId == student.Id)
                                   .Sum(lts => lessonTimes[lts.LessonId]));
            return maxLessonTime;

        }
    }
}
/*
A DERSİ = 100DK
B DERSİ = 50DK
C DERSİ = 70DK
AHMET - A+B+C = 220DK
MEHMET - A+C = 170DK
AYŞE - A+B = 150DK
MUSTAFA - B = 50DK

1. SORGU
AHMET, MEHMET, AYŞE
2. SORGU 
AHMET, AYŞE, MUSTAFA 
3. SORGU
AHMET , MEHMET
 */