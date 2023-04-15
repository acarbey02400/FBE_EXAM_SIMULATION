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
    public interface IDegreeService
    {
        public IResult add(Degree degree);
        public IResult update(Degree degree);
        public IResult delete(Degree degree);
        public IDataResult<List<Degree>> getAll();
        public IDataResult<List<Degree>> getByName(string name);
        public IDataResult<Degree> getById(int id);
    }
}
