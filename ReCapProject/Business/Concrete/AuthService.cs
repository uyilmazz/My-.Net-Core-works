using Business.Abstract;
using Business.Constants.Message;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthService(ITokenHelper tokenHelper, IUserService userService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var token = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(token, MessageText.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var checkEmail = _userService.GetByMail(userForLoginDto.Email);
            if (!checkEmail.Success)
            {
                return new ErrorDataResult<User>(MessageText.UserNotFound);
            }

            var passwordVerify = HashingHelper.VerifyPasswordHash(userForLoginDto.Password, checkEmail.Data.PasswordSalt,checkEmail.Data.PasswordHash);
            if (!passwordVerify)
            {
                return new ErrorDataResult<User>(MessageText.PasswordError);
            }
            return new SuccessDataResult<User>(checkEmail.Data,MessageText.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordSalt,out passwordHash);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName =  userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,MessageText.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.Success)
                return new ErrorResult(MessageText.UserAlreadyExists);
            return new SuccessResult();
        }
    }
}
