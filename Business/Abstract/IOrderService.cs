using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        public IResult add(Order order);
        public IResult update(Order order);
        public IResult delete(Order order);
        public IDataResult<List<Order>> getAll();
        public IDataResult<List<Order>> getByOrderNo(string no);
        public IDataResult<Order> getById(int id);

    }
}
