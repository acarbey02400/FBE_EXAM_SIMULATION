using Core.DataAccess.EntityFramework.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess.Abstract
{
    public interface IStudentDal : IEntityRepository<Student>
    {
        public List<StudentDetailDto> GetStudentDetails();
    }
}
