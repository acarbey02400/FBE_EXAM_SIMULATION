using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FacultiyManager : IFacultiyService
    {
        IFacultyDal _facultiyDal;
        public FacultiyManager(IFacultyDal facultiyDal)
        {
            _facultiyDal = facultiyDal;
        }
        public IResult add(Facultiy facultiy)
        {
            _facultiyDal.Add(facultiy);
            return new SuccessResult();
        }

        public IResult delete(Facultiy facultiy)
        {
            facultiy.isDeleted = true;
            _facultiyDal.Update(facultiy);
            return new SuccessResult();
        }

        public IDataResult<List<Facultiy>> getAll()
        {
           return new SuccessDataResult<List<Facultiy>>(_facultiyDal.GetAll());
        }

        public IDataResult<Facultiy> getById(int id)
        {
            return new SuccessDataResult<Facultiy>(_facultiyDal.Get(p=>p.Id == id));
        }

        public IDataResult<List<Facultiy>> getByName(string name)
        {
            return new SuccessDataResult<List<Facultiy>>(_facultiyDal.GetAll(p=>p.Name == name));
        }

        public IResult update(Facultiy facultiy)
        {
            _facultiyDal.Update(facultiy);
            return new SuccessResult();
        }
    }
}
