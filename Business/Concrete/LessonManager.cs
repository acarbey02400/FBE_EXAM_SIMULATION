using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.BusinessRules;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [SecuredOperation("admin")]
    public class LessonManager : ILessonService
    {
        ILessonDal _lessonDal;
        LessonBusinuessRules _rules;
        public LessonManager(ILessonDal lessonDal, LessonBusinuessRules rules)
        {
            _lessonDal = lessonDal;
            _rules = rules;
        }
        public IResult add(Lesson lesson)
        {
            _lessonDal.Add(lesson);
            return new SuccessResult();
        }

        public IResult delete(Lesson lesson)
        {
            lesson.isDeleted = true;
            _lessonDal.Update(lesson);
            return new SuccessResult();
        }

        public IDataResult<List<LessonDetailDto>> getLessonDetails()
        {
            return new SuccessDataResult<List<LessonDetailDto>>(_lessonDal.GetLessonDetails());
        }

        public IDataResult<List<Lesson>> getAll()
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll());
        }
       
        public IDataResult<List<Lesson>> getByDepartmentId(int id)
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(p=>p.DepartmentId == id));
        }

        public IDataResult<List<Session>> getByExamDateTime(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Lesson>> getByExamId(int id)
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(p => p.ExamId == id));
        }

        public IDataResult<Lesson> getById(int id)
        {
            return new SuccessDataResult<Lesson>(_lessonDal.Get(p=>p.Id == id));
        }

        public IDataResult<Lesson> getByLessonCode(string code)
        {
            return new SuccessDataResult<Lesson>(_lessonDal.Get(p => p.LessonCode == code));
        }

        public IDataResult<List<Lesson>> getByName(string name)
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(p=>p.Name== name));
        }

        public IDataResult<List<Lesson>> getBySemesterId(int id)
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(p=>p.SemesterId== id));
        }

        public IDataResult <List<Lesson>> getBySessionId(int id)
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(p=>p.Id== id));
        }

        public IDataResult<List<Lesson>> getByStaffId(int id)
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(p=>p.StaffId== id));
        }

        public IDataResult<List<Lesson>> getByTypeExamId(int id)
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(p=>p.ExamId== id));
        }

        public IResult update(Lesson lesson)
        {
            _lessonDal.Update(lesson);
            return new SuccessResult();
        }

        public IResult updateRange(List<Lesson> lessons)
        {
            _lessonDal.UpdateRange(lessons);
            return new SuccessResult();
        }

        public IDataResult<List<Lesson>> getByExamToFacultiy(int examId)
        {
            var depList=_rules.GetDepartmentId(examId);
            return new SuccessDataResult<List<Lesson>>( _lessonDal.GetAll(p => depList.Contains(p.DepartmentId)));
        }
    }
}
