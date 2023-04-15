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
    public interface IClassromService
    {
        public IResult add(Classrom classrom);
        public IResult update(Classrom classrom);
        public IResult delete(Classrom classrom);
        public IDataResult<List<Classrom>> getAll();
        public IDataResult<List<Classrom>> getByClassNo(string classNo);
        public IDataResult<Classrom> getById(int id);
       
    }
}
