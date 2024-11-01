﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILessonDal : IEntityRepository<Lesson>
    {
        public List<LessonDetailDto> GetLessonDetails();
        public void UpdateRange(List<Lesson> lessons);
    }
}
