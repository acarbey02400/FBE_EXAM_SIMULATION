using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class LessonDetailDto:IDto
    {
        public int LessonId { get; set; }
        public string? LessonName { get; set;}
        public string? LessonCode { get; set; }
        public string? DepartmentName { get; set; }
        public string? StaffName { get; set; }
        public string? SessionName { get; set; }
        public string? SemesterName { get; set; }
        public string? YearName { get; set; }
        public string? ExamName { get; set; }
        public int LessonTime { get; set; }
        public bool isDeleted { get; set; }
    }
}
