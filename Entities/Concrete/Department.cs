﻿using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Department:IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
