using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities;
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
    [SecuredOperation("admin")]
    public class YearManager : IYearService
    {
        IYearDal _yearDal;
        public YearManager(IYearDal yearDal)
        {
            _yearDal = yearDal;
        }
        public IResult add(Year year)
        {
            _yearDal.Add(year);
            return new SuccessResult();
        }

        public IResult delete(Year year)
        {
            year.isDeleted = true;
            _yearDal.Update(year);
            return new SuccessResult();
        }

        public IDataResult<List<Year>> getAll()
        {
            return new SuccessDataResult<List<Year>>(_yearDal.GetAll());
        }

        public IDataResult<List<Year>> getByDateTime(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Year> getById(int id)
        {
            return new SuccessDataResult<Year>(_yearDal.Get(p=>p.Id == id));
        }

        public IResult update(Year year)
        {
            _yearDal.Update(year);
            return new SuccessResult();
        }
    }
}