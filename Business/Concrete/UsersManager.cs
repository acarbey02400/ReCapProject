using Business.Absract;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UsersManager : IUsersService
    {
        IUsersDal _usersDal;
        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }
        public IResult Add(User user)
        {
            _usersDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _usersDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_usersDal.GetAll());
        }

        public IResult Update(User user)
        {
            _usersDal.Update(user);
            return new SuccessResult();
        }
    }
}
