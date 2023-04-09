using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISemesterService
    {
        public IResult add(Semester semester);
        public IResult update(Semester semester);
        public IResult delete(Semester semester);
        public IDataResult<List<Semester>> getAll();
        public IDataResult<List<Semester>> getByName(string name);
        public IDataResult<Semester> getById(int id);

    }
}
