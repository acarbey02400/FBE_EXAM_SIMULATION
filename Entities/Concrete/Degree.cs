﻿using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Degree:IEntity
    {
        public bool isDeleted { get; set; } = false;
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
