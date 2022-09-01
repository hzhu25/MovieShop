using System;
using ApplicationCore.Contracts.Repositories;
using System.Security.Cryptography;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> RegisterUser(UserRegisterModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user != null)
            {
                throw new Exception("Email already exists, try to login");
            }


            var salt = GetRandomSalt();

            var hashedPassword = GetHashedPassword(model.Password, salt);

            var dbUser = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                DateOfBirth = model.DateOfBirth
            };

            var createdUser = await _userRepository.AddUser(dbUser);
            return createdUser.Id;
        }

        public async Task<UserLoginSuccessModel> ValidateUser(UserLoginModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user == null)
            {
                throw new Exception("Email does not exixts, try to register first");
            }

            var hashedPassword = GetHashedPassword(model.Password, user.Salt);

            if (user.HashedPassword == hashedPassword)
            {
                var userLoginSuccessModel = new UserLoginSuccessModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                return userLoginSuccessModel;
            }

            return null;
        }


        private string GetRandomSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string GetHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
           password,
           Convert.FromBase64String(salt),
           KeyDerivationPrf.HMACSHA512,
           10000,
           256 / 8));
            return hashed;
        }
    }
}
