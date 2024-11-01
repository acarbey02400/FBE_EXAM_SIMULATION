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
    public class TypeOfExamManager : ITypeOfExamService
    {
        ITypeOfExamDal _typeOfExamDal;
        public TypeOfExamManager(ITypeOfExamDal typeOfExamDal)
        {
            _typeOfExamDal = typeOfExamDal;
        }
        public IResult add(TypeOfExam typeOfExam)
        {
            _typeOfExamDal.Add(typeOfExam);
            return new SuccessResult();
        }

        public IResult delete(TypeOfExam typeOfExam)
        {
            typeOfExam.isDeleted = true;
            _typeOfExamDal.Update(typeOfExam);
            return new SuccessResult();
        }

        public IDataResult<List<TypeOfExam>> getAll()
        {
            return new SuccessDataResult<List<TypeOfExam>>(_typeOfExamDal.GetAll());
        }

        public IDataResult<TypeOfExam> getById(int id)
        {
            return new SuccessDataResult<TypeOfExam>(_typeOfExamDal.Get(p=>p.Id == id));
        }

        public IDataResult<List<TypeOfExam>> getByName(string name)
        {
            return new SuccessDataResult<List<TypeOfExam>>(_typeOfExamDal.GetAll(p=>p.Name == name));
        }

        public IResult update(TypeOfExam typeOfExam)
        {
            _typeOfExamDal.Update(typeOfExam);
            return new SuccessResult();
        }
    }
}
