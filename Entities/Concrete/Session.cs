﻿using Core.Entities.Abstract;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Session:IEntity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ExamId { get; set; }
    }
}
