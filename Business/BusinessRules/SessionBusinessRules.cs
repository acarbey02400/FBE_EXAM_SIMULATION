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
        private readonly ILessonService _lessonService;
        public SessionBusinessRules(IlessonToStudentService lessonToStudentService,  IStudentService studentService,ILessonService lessonService)
        {
            _lessonToStudentService = lessonToStudentService;
            _studentService = studentService;
            _lessonService= lessonService;
        }

        public int CheckSessionTime(List<Lesson> lessons)
        {
            // Derslere göre öğrenci eşlemelerini lessonToStudentList'e ekle
            var lessonToStudentList = lessons
                .SelectMany(lesson => _lessonToStudentService.getByLessonId(lesson.Id).Data)
                .ToList();

            // Ders ID'lerine göre ders sürelerini bir sözlükte tut
            var DicLessons =lessons
                .ToDictionary(x => x.Id, x => x.LessonTime);

            // Her öğrenci için aldığı derslerin toplam süresini hesapla ve en büyüğünü bul
            var maxLessonTime = lessonToStudentList
                .GroupBy(x => x.StudentId)
                .Select(g => g.Sum(x => DicLessons[x.LessonId]))
                .Max();

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