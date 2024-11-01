﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Lesson:IEntity
    {
        public int Id { get; set; }
        public string? LessonCode { get; set; }
        public string? Name  { get; set; }
        public int DepartmentId { get; set; }
        public int StaffId { get; set; }
        public int SessionId { get; set; } 
        public int ExamId { get; set; }
        public int SemesterId { get; set; }
        public int YearId { get; set; }
        public int LessonTime { get; set; }
        public bool isDeleted { get; set; } = false;
        public IEnumerable<Student>? Students { get; set; }
    }
}
