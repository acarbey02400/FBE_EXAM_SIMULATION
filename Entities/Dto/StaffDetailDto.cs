using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class StaffDetailDto:IDto
    {
        public int StaffId { get; set; }
        public string? StaffName { get; set; }
        public string? StaffSurname { get; set; }
        public bool isDeleted { get; set; }
        public string? DegreeName { get; set; }
    }
}
