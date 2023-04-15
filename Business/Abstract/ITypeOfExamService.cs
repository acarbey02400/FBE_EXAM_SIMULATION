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
    public interface ITypeOfExamService
    {
        public IResult add(TypeOfExam typeOfExam);
        public IResult update(TypeOfExam typeOfExam);
        public IResult delete(TypeOfExam typeOfExam);
        public IDataResult<List<TypeOfExam>> getAll();
        public IDataResult<List<TypeOfExam>> getByName(string name);
        public IDataResult<TypeOfExam> getById(int id);
    }
}
