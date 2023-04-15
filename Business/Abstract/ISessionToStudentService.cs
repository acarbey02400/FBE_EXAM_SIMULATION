using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISessionToStudentService
    {
        public IResult add(SessionToStudent sessionToStudent);
        public IResult update(SessionToStudent sessionToStudent);
        public IResult delete(SessionToStudent sessionToStudent);
        public IDataResult<List<SessionToStudent>> getAll();
        public IDataResult<SessionToStudent> getById(int id);
        public IDataResult <List<SessionToStudent>> getBySessionId(int id);//list
        public IDataResult <List<SessionToStudent>> getByStudentId(int id);
    }
}
