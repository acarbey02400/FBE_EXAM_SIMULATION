﻿using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LessonToStudentManager : IlessonToStudentService
    {
        ILessonToStudentDal _lessonToStudentDal;
        public LessonToStudentManager(ILessonToStudentDal lessonToStudentDal)
        {
            _lessonToStudentDal = lessonToStudentDal;
        }
        public IResult add(LessonToStudent lessonToStudent)
        {
            _lessonToStudentDal.Add(lessonToStudent);
            return new SuccessResult();
        }

        public IResult delete(LessonToStudent lessonToStudent)
        {
           _lessonToStudentDal.Delete(lessonToStudent);
            return new SuccessResult();
        }

        public IDataResult<List<LessonToStudent>> getAll()
        {
            return new SuccessDataResult<List<LessonToStudent>>(_lessonToStudentDal.GetAll());
        }

        public IDataResult<LessonToStudent> getById(int id)
        {
            return new SuccessDataResult<LessonToStudent>(_lessonToStudentDal.Get(p => p.Id == id));
        }

        public IDataResult<List<LessonToStudent>> getByLessonId(int id)
        {
            return new SuccessDataResult<List<LessonToStudent>>(_lessonToStudentDal.GetAll(p=>p.LessonId == id));
        }

        public IDataResult<List<LessonToStudent>> getByStudentId(int id)
        {
            return new SuccessDataResult<List<LessonToStudent>>(_lessonToStudentDal.GetAll(p => p.StudentId == id));
        }

        public IResult update(LessonToStudent lessonToStudent)
        {
            _lessonToStudentDal.Update(lessonToStudent);
            return new SuccessResult();
        }
    }
}