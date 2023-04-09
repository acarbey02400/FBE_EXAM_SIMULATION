﻿using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStaffService
    {
        public IResult add(Staff staff);
        public IResult update(Staff staff);
        public IResult delete(Staff staff);
        public IDataResult<List<Staff>> getAll();
        public IDataResult<List<Staff>> getByName(string name);
        public IDataResult<Staff> getById(int id);
        public IDataResult<List<Staff>> getByDegreeId(int id);
    }
}
