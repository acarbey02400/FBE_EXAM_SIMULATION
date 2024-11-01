﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [SecuredOperation("admin")]
    public class SessionToStudentManager : ISessionToStudentService
    {
        ISessionToStudentDal _sessionToStudentDal;
        public SessionToStudentManager(ISessionToStudentDal sessionToStudentDal)
        {
            _sessionToStudentDal = sessionToStudentDal;
        }
        public IResult add(SessionToStudent sessionToStudent)
        {
            _sessionToStudentDal.Add(sessionToStudent);
            return new SuccessResult();
        }

        public IResult delete(SessionToStudent sessionToStudent)
        {
            sessionToStudent.isDeleted = true;
            _sessionToStudentDal.Update(sessionToStudent);
            return new SuccessResult();
        }

        public IDataResult<List<SessionToStudent>> getAll()
        {
            return new SuccessDataResult<List<SessionToStudent>>(_sessionToStudentDal.GetAll());
        }

        public IDataResult<SessionToStudent> getById(int id)
        {
           return new SuccessDataResult<SessionToStudent>(_sessionToStudentDal.Get(p=>p.Id == id)); 
        }

        public IDataResult<List<SessionToStudent>> getBySessionId(int id)
        {
            return new SuccessDataResult<List<SessionToStudent>>(_sessionToStudentDal.GetAll(p=>p.SessionId==id));
        }

        public IDataResult<List<SessionToStudent>> getByStudentId(int id)
        {
            return new SuccessDataResult<List<SessionToStudent>>(_sessionToStudentDal.GetAll(p=>p.StudentId == id)); 
        }

        public IResult update(SessionToStudent sessionToStudent)
        {
            _sessionToStudentDal.Update(sessionToStudent);
            return new SuccessResult();
        }
    }
}
