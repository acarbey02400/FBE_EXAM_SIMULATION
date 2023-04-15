using Business.Abstract;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Core.Utilities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Results;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                eMail = userForRegisterDto.Email,
                firstName = userForRegisterDto.FirstName,
                lastName = userForRegisterDto.LastName,
                passwordHash = passwordHash,
                passwordSalt = passwordSalt,
                status = true
            };
            _userService.add(user);
            return new SuccessDataResult<User>(user, "Başarıyla kayıt olundu");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.passwordHash, userToCheck.passwordSalt))
            {
                return new ErrorDataResult<User>("Girdiğiniz şifre hatalı");
            }

            return new SuccessDataResult<User>(userToCheck, "Giriş Başarılı");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("Kullanıcı mevcut");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }
    }
}
