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
    public interface IFacultiyService
    {
        public IResult add(Facultiy facultiy);
        public IResult update(Facultiy facultiy);
        public IResult delete(Facultiy facultiy);
        public IDataResult<List<Facultiy>> getAll();
        public IDataResult<List<Facultiy>> getByName(string name);
        public IDataResult<Facultiy> getById(int id);
        
    }
}
