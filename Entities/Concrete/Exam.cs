using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Exam:IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int FacultiyId { get; set; }
        public int YearId { get; set; }
        public int SemesterId { get; set; }
        public int DepartmentId { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
