using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Student:IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Number { get; set; }
        public int DepartmentId { get; set; }
        public int FacultyId { get; set; }
        public int SemesterId { get; set; }
        public int YearId { get; set; }
        public int TeachTypeId { get; set; }
        public int ClassromId { get; set; }
        public int OrderId { get; set; }
        public int ExamId { get; set; }
        public bool isDeleted { get; set; } = false;

    }
}
