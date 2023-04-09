using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISessionService
    {
        public IResult add(Session session);
        public IResult update(Session session);
        public IResult delete(Session session);
        public IDataResult<List<Session>> getAll();
        public IDataResult<Session> getById(int id);
        public IDataResult<Session> getByExamId(int id);
        public IDataResult<List<Session>> getByDateTime(DateTime dateTime);
    }
 

}


