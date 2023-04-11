using Business.Abstract;
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
    public class SessionManager : ISessionService
    {
        ISessionDal _sessionDal;
        public SessionManager(ISessionDal sessionDal)
        {
            _sessionDal=sessionDal;
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
            return new SuccessDataResult<Session>(_sessionDal.Get(p=>p.ExamId == id));
        }

        public IDataResult<Session> getById(int id)
        {
            return new SuccessDataResult<Session>(_sessionDal.Get(p=>p.Id == id));
        }

        public IResult update(Session session)
        {
            _sessionDal.Update(session);
            return new SuccessResult();
        }
    }
}
