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
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public IResult add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult();
        }

        public IResult delete(Order order)
        {
            order.isDeleted = true;
            _orderDal.Update(order);   
            return new SuccessResult();
        }

        public IDataResult<List<Order>> getAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }

        public IDataResult<Order> getById(int id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(p=>p.Id == id));  
        }

        public IDataResult<List<Order>> getByOrderNo(string no)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(p=>p.OrderNo == no));
        }

        public IResult update(Order order)
        {
           _orderDal.Update(order);
            return new SuccessResult();
        }
    }
}
