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
    public class SessionManager : ISessionService
    {
        ISessionDal _sessionDal;
        SessionBusinessRules _sessionBusinessRules;
        public SessionManager(ISessionDal sessionDal, SessionBusinessRules sessionBusinessRules)
        {
            _sessionDal = sessionDal;
            _sessionBusinessRules = sessionBusinessRules;
        }
        public IResult add(Session session)
        {
            _sessionDal.Add(session);
            return new SuccessResult();
        }

        public IResult delete(Session session)
        {
            session.isDeleted = true;
            _sessionDal.Update(session);
            return new SuccessResult();
        }

        public IDataResult<List<SessionDetailDto>> getSessionDetails()
        {
            return new SuccessDataResult<List<SessionDetailDto>>(_sessionDal.GetSessionDetails());
        }

        public IDataResult<List<Session>> getAll()
        {
            return new SuccessDataResult<List<Session>>(_sessionDal.GetAll());
        }

        public IDataResult<List<Session>> getByDateTime(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Session> getByExamId(int id)
        {
            return new SuccessDataResult<Session>(_sessionDal.Get(p => p.ExamId == id));
        }

        public IDataResult<Session> getById(int id)
        {
            return new SuccessDataResult<Session>(_sessionDal.Get(p => p.Id == id));
        }

        public IResult update(Session session)
        {
            _sessionDal.Update(session);
            return new SuccessResult();
        }
        public IResult CheckSessionTime(List<Lesson> lessons)
        {
            return new SuccessDataResult<int>(_sessionBusinessRules.CheckSessionTime(lessons));
        }
    }
}
