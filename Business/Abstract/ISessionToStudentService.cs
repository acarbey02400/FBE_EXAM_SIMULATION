using Core.Utilities;
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
        public IDataResult<SessionToStudent> getBySessionId(int id);
        public IDataResult<SessionToStudent> getByStudentId(int id);
    }
}
