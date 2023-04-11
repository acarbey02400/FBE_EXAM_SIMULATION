using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class SessionDetailDto:IDto
    {
        public int SessionId { get; set; }
        public string? SessionName { get; set; }
        public DateTime DateTime { get; set; }
        public string? ExamName { get; set; }
        public bool isDeleted { get; set; }
    }
}
