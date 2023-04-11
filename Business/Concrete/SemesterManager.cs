using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SemesterManager : ISemesterService
    {
        ISemesterDal _semesterDal;
        public SemesterManager(ISemesterDal semesterDal)
        {
            _semesterDal = semesterDal;
        }
        public IResult add(Semester semester)
        {
            _semesterDal.Add(semester);
            return new SuccessResult();
        }

        public IResult delete(Semester semester)
        {
            semester.isDeleted = true;
            _semesterDal.Update(semester);
            return new SuccessResult();
        }

        public IDataResult<List<Semester>> getAll()
        {
            return new SuccessDataResult<List<Semester>>(_semesterDal.GetAll());
        }

        public IDataResult<Semester> getById(int id)
        {
            return new SuccessDataResult<Semester>(_semesterDal.Get(p=>p.Id == id));
        }

        public IDataResult<List<Semester>> getByName(string name)
        {
            return new SuccessDataResult<List<Semester>>(_semesterDal.GetAll(p=>p.Name == name));
        }

        public IResult update(Semester semester)
        {
            _semesterDal.Update(semester);
            return new SuccessResult();
        }
    }
}
