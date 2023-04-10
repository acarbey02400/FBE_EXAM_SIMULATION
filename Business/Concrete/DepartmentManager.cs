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
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal; 
        }
        public IResult add(Department department)
        {
            _departmentDal.Add(department);
            return new SuccessResult();
        }

        public IResult delete(Department department)
        {
            _departmentDal.Delete(department);
            return new SuccessResult();
        }

        public IDataResult<List<Department>> getAll()
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetAll());
        }

        public IDataResult<Department> getById(int id)
        {
            return new SuccessDataResult<Department>(_departmentDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Department>> getByName(string name)
        {
            return new SuccessDataResult<List<Department>>(_departmentDal.GetAll(p=> p.Name == name));
        }

        public IResult update(Department department)
        {
            _departmentDal.Update(department);
            return new SuccessResult();
        }
    }
}
