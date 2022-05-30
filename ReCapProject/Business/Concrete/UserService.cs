using Business.Abstract;
using Business.Constants.Message;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        IUserDal _userDal;

        public UserService(IUserDal userdal)
        {
            _userDal = userdal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(MessageText.SuccessMessage);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(MessageText.SuccessMessage);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), MessageText.SuccessMessage);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(c => c.Id == id));
        }

        public IResult Update(User customer)
        {
            _userDal.Update(customer);
            return new SuccessResult(MessageText.SuccessMessage);
        }
    }
}
