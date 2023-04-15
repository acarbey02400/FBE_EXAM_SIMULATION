using Core.DataAccess.EntityFramework;
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
    public class EfSessionDal : EfEntityRepositoryBase<Session, SauDbContext>, ISessionDal
    {
        
        public List<SessionDetailDto> GetSessionDetails()
        {
            using (SauDbContext context = new SauDbContext())
            {
                var result = from ses in context.Sessions
                             join e in context.Exams
                             on ses.ExamId equals e.Id
                             select new SessionDetailDto
                             {
                                 DateTime = ses.DateTime,
                                 SessionId = ses.Id,
                                 SessionName = ses.Name,
                                 ExamName = e.Name,
                                 isDeleted = ses.isDeleted
                             };
                return result.ToList();
            }

        }
    }
}
