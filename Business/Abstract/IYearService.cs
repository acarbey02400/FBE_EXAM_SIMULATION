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
    public interface IYearService
    {
        public IResult add(Year year);
        public IResult update(Year year);
        public IResult delete(Year year);
        public IDataResult<List<Year>> getAll();
        public IDataResult<List<Year>> getByDateTime(DateTime dateTime);
        public IDataResult<Year> getById(int id);
    }
}
