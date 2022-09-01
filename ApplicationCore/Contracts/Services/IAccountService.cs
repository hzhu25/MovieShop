﻿using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IAccountService
    {
        Task<UserLoginSuccessModel> ValidateUser(UserLoginModel model);
        Task<int> RegisterUser(UserRegisterModel model);
    }
}

