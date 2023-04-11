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
    public class ClassromManager : IClassromService
    {
        IClassromDal _classromDal;
        public ClassromManager(IClassromDal classromDal)
        {
            _classromDal = classromDal;
        }
        public IResult add(Classrom classrom)
        {
            _classromDal.Add(classrom);
            return new SuccessResult();
        }

        public IResult delete(Classrom classrom)
        {
            classrom.isDeleted=true;
            _classromDal.Update(classrom);
            return new SuccessResult();
        }

        public IDataResult<List<Classrom>> getAll()
        {
            return new SuccessDataResult<List<Classrom>>(_classromDal.GetAll()); 
        }

        public IDataResult<List<Classrom>> getByClassNo(string classNo)
        {
            return new SuccessDataResult<List<Classrom>>(_classromDal.GetAll(p=>p.ClassromNo==classNo));
        }

        public IDataResult<Classrom> getById(int id)
        {
            return new SuccessDataResult<Classrom>(_classromDal.Get(p=>p.Id==id));
        }

        public IResult update(Classrom classrom)
        {
            _classromDal.Update(classrom);
            return new SuccessResult();
        }
    }
}
