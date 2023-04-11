using Core.DataAccess.EntityFramework.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStaffDal : EfEntityRepositoryBase<Staff, SauDbContext>, IStaffDal
    {
       
        public List<StaffDetailDto> GetStaffDetails()
        {
            using (SauDbContext contex = new SauDbContext())
            {
                var result = from s in contex.Staffs
                             join d in contex.Degrees
                             on s.DegreeId equals d.Id
                             select new StaffDetailDto
                             {
                                 DegreeName = d.Name,
                                 isDeleted = s.isDeleted,
                                 StaffId = s.Id,
                                 StaffName = s.Name,
                                 StaffSurname = s.SurName
                             };
                return result.ToList();
            }
        }
    }
}
