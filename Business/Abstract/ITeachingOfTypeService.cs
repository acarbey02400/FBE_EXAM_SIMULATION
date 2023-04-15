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
    public interface ITeachingOfTypeService
    {
        public IResult add(TeachingOfType teachingOfType);
        public IResult update(TeachingOfType teachingOfType);
        public IResult delete(TeachingOfType teachingOfType);
        public IDataResult<List<TeachingOfType>> getAll();
        public IDataResult<List<TeachingOfType>> getByName(string name);
        public IDataResult<TeachingOfType> getById(int id);
    }
}
