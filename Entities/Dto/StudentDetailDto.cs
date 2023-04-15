using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class StudentDetailDto:IDto
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentSurname { get; set; }
        public string? StudentNumber { get; set; }
        public string? DepartmentName { get; set; }
        public string? FacultyName { get; set; }
        public string? SemesterName { get; set; }
        public string? YearName { get; set; }
        public string? TeachTypeName { get; set; }
        public string? ClassromName { get; set; }
        public string? OrderName { get; set; }
        public bool isDeleted { get; set; }
    }
}
