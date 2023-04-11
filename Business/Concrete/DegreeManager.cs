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
    public class DegreeManager : IDegreeService
    {
        IDegreeDal _degreDal;
        public DegreeManager(IDegreeDal degreDal)
        {
            _degreDal = degreDal;
        }
        public IResult add(Degree degree)
        {
            _degreDal.Add(degree);
            return new SuccessResult();
        }

        public IResult delete(Degree degree)
        {
            degree.isDeleted = true;
            _degreDal.Update(degree);
            return new SuccessResult();
        }

        public IDataResult<List<Degree>> getAll()
        {
            return new SuccessDataResult<List<Degree>>(_degreDal.GetAll());
        }

        public IDataResult<Degree> getById(int id)
        {
            return new SuccessDataResult<Degree>(_degreDal.Get(p=>p.Id==id));
        }

        public IDataResult<List<Degree>> getByName(string name)
        {
            return new SuccessDataResult<List<Degree>>(_degreDal.GetAll(p=>p.Name==name));
        }

        public IResult update(Degree degree)
        {
            _degreDal.Update(degree);
            return new SuccessResult();
        }
    }
}
