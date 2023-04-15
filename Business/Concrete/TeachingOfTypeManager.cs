using Business.Abstract;
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
    public class TeachingOfTypeManager : ITeachingOfTypeService
    {
        ITeachingOfTypeDal _teachingOfTypeDal;
        public TeachingOfTypeManager(ITeachingOfTypeDal teachingOfTypeDal)
        {
            _teachingOfTypeDal = teachingOfTypeDal;
        }
        public IResult add(TeachingOfType teachingOfType)
        {
            _teachingOfTypeDal.Add(teachingOfType);
            return new SuccessResult();
        }

        public IResult delete(TeachingOfType teachingOfType)
        {
            teachingOfType.isDeleted = true;
            _teachingOfTypeDal.Update(teachingOfType);
            return new SuccessResult();
        }

        public IDataResult<List<TeachingOfType>> getAll()
        {
            return new SuccessDataResult<List<TeachingOfType>>(_teachingOfTypeDal.GetAll());
        }

        public IDataResult<TeachingOfType> getById(int id)
        {
            return new SuccessDataResult<TeachingOfType>(_teachingOfTypeDal.Get(p=>p.Id == id));
        }

        public IDataResult<List<TeachingOfType>> getByName(string name)
        {
            return new SuccessDataResult<List<TeachingOfType>>(_teachingOfTypeDal.GetAll(p=>p.Name==name));
        }

        public IResult update(TeachingOfType teachingOfType)
        {
            _teachingOfTypeDal.Update(teachingOfType);
            return new SuccessResult();
        }
    }
}
