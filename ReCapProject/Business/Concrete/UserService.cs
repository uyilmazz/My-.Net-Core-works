using Business.Abstract;
using Business.Constants.Message;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
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

        public IDataResult<CustomerUserDto> GetByEmail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if(result is null)
            {
                return new ErrorDataResult<CustomerUserDto>(MessageText.UserNotFound);
            }
            var userDetailDto = new CustomerUserDto
            {
                Email = result.Email,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Id = result.Id
            };
            return new SuccessDataResult<CustomerUserDto>(userDetailDto);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(c => c.Id == id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result is null)
                return new ErrorDataResult<User>(MessageText.EmailNotFound);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(User customer)
        {
            _userDal.Update(customer);
            return new SuccessResult(MessageText.SuccessMessage);
        }
    }
}
