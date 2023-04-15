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
    public interface IExamService
    {
        public IResult add(Exam exam);
        public IResult update(Exam exam);
        public IResult delete(Exam exam);
        public IDataResult<List<Exam>> getAll();
        public IDataResult<List<Exam>> getByName(string name);
        public IDataResult<Exam> getById(int id);
        public IDataResult <List<Exam>> getByYearId(int id);//list
        public IDataResult <List<Exam>> getByFacultiyId(int id);
        public IDataResult <List<Exam>> getBySemesterId(int id);
    }
}
