using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        public IResult add(Department department);
        public IResult update(Department department);
        public IResult delete(Department department);
        public IDataResult<List<Department>> getAll();
        public IDataResult<List<Department>> getByName(string name);
        public IDataResult<Department> getById(int id);
    }
}
