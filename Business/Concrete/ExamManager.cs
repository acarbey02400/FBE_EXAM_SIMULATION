﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [SecuredOperation("admin")]
    public class ExamManager : IExamService
    {
        IExamDal _examDal;
        public ExamManager(IExamDal examDal)
        {
            _examDal = examDal;
        }
        public IResult add(Exam exam)
        {
            _examDal.Add(exam);
            return new SuccessResult();
        }

        public IResult delete(Exam exam)
        {
            
            exam.isDeleted = true;
            _examDal.Update(exam);
            return new SuccessResult();
        }

        public IDataResult<List<Exam>> getAll()
        {
            return new SuccessDataResult<List<Exam>>(_examDal.GetAll());
        }

        public IDataResult<List<Exam>> getByDepartmentId(int id)
        {
            return new SuccessDataResult<List<Exam>>(_examDal.GetAll(p => p.DepartmentId == id));
        }

        public IDataResult<List<Exam>> getByFacultiyId(int id)
        {
            return new SuccessDataResult<List<Exam>>(_examDal.GetAll(p => p.FacultiyId == id));
        }

        public IDataResult<Exam> getById(int id)
        {
            return new SuccessDataResult<Exam>(_examDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Exam>> getByName(string name)
        {
            return new SuccessDataResult<List<Exam>>(_examDal.GetAll(p => p.Name == name));
        }

        public IDataResult<List<Exam>> getBySemesterId(int id)
        {
            return new SuccessDataResult<List<Exam>>(_examDal.GetAll(p => p.SemesterId == id));
        }

        public IDataResult<List<Exam>> getByYearId(int id)
        {
            return new SuccessDataResult<List<Exam>>(_examDal.GetAll(p => p.YearId == id));
        }

        public IResult update(Exam exam)
        {
            _examDal.Update(exam);
            return new SuccessResult();
        }
    }
}
