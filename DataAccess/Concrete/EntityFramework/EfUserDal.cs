using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, SauDbContext>, IUserDal
    {
        public List<Core.Entities.Concrete.OperationClaim> GetClaims(User user)
        {
            using (var context = new SauDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.id equals userOperationClaim.operationClaimId
                             where userOperationClaim.userId == user.id
                             select new Core.Entities.Concrete.OperationClaim { id = operationClaim.id, name = operationClaim.name };
                return result.ToList();

            }
        }
    }
}
