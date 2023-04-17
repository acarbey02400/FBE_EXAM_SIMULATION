using Business.Abstract;
using Core.Aspects.Autofac.Validation;
using Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Core.Entities.Concrete;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    [SecuredOperation("admin")]
    public class UserManager : IUserService
        {
            IUserDal _userDal;

            public UserManager(IUserDal userDal)
            {
                _userDal = userDal;
            }



            public IResult add(User user)
            {
                _userDal.Add(user);
                return new SuccessResult();
            }

            public IResult delete(User user)
            {

                _userDal.Delete(user);
                return new SuccessResult();
            }

            public IDataResult<List<User>> getAll()
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll());
            }

            public IDataResult<User> getById(int id)
            {
                return new SuccessDataResult<User>(_userDal.Get(p => p.id == id));
            }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.eMail == email);
        }

        public IDataResult<List<User>> getByTypeId(int UserType)
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll(p => p.userTypeId == UserType));
            }

        public List<Core.Entities.Concrete.OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult update(User user)
            {

                _userDal.Update(user);
                return new SuccessResult();
            }


        }
    }
