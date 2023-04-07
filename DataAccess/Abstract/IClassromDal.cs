using Core.DataAccess.EntityFramework.Abstract;
using Core.DataAccess.EntityFramework.Concrete;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IClassromDal:IEntityRepository<Classrom>
    {
    }
}
