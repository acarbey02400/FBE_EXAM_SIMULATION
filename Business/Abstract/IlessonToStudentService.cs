using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IlessonToStudentService
    {
        public IResult add(LessonToStudent lessonToStudent);
        public IResult update(LessonToStudent lessonToStudent);
        public IResult delete(LessonToStudent lessonToStudent);
        public IDataResult<List<LessonToStudent>> getAll();
        public IDataResult<LessonToStudent> getById(int id);
        public IDataResult <List<LessonToStudent>> getByLessonId(int id);
        public IDataResult <List<LessonToStudent>> getByStudentId(int id);
    }
}
