using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [SecuredOperation("admin")]
    public class StaffManager : IStaffService
    {
        IStaffDal _staffDal;
        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }
        public IResult add(Staff staff)
        {
            _staffDal.Add(staff);
            return new SuccessResult();
        }

        public IResult delete(Staff staff)
        {
            staff.isDeleted = true;
            _staffDal.Update(staff);
            return new SuccessResult();
        }

        public IDataResult<List<StaffDetailDto>> geStaffDetails()
        {
            return new SuccessDataResult<List<StaffDetailDto>>(_staffDal.GetStaffDetails());
        }

        public IDataResult<List<Staff>> getAll()
        {
            return new SuccessDataResult<List<Staff>>(_staffDal.GetAll());
        }

        public IDataResult<List<Staff>> getByDegreeId(int id)
        {
           return new SuccessDataResult<List<Staff>>(_staffDal.GetAll(p=>p.DegreeId==id));
        }

        public IDataResult<Staff> getById(int id)
        {
            return new SuccessDataResult<Staff>(_staffDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Staff>> getByName(string name)
        {
           return new SuccessDataResult<List<Staff>>(_staffDal.GetAll(p=>p.Name==name));
        }

        public IResult update(Staff staff)
        {
            _staffDal.Update(staff);
            return new SuccessResult();
        }
    }
}
