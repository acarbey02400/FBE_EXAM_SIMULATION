using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILessonService
    {
        public IResult add(Lesson lesson);
        public IResult update(Lesson lesson);
        public IResult delete(Lesson lesson);
        public IDataResult<List<Lesson>> getAll();
        public IDataResult<List<Lesson>> getByName(string name);
        public IDataResult<Lesson> getById(int id);
        public IDataResult<Lesson> getByLessonCode(string code);
        public IDataResult <List<Lesson>> getByDepartmentId(int id);
        public IDataResult<List<Lesson>> getByStaffId(int id);
        public IDataResult <List<Lesson>> getBySessionId(int id);
        public IDataResult <List<Lesson>> getBySemesterId(int id);
        public IDataResult <List<Lesson>> getByTypeExamId(int id);
        public IDataResult <List<Lesson>> getByExamId(int id);
        public IDataResult<List<Session>> getByExamDateTime(DateTime dateTime);
        public IDataResult<List<LessonDetailDto>> getLessonDetails();
    }
}
