using ChefBox.Model.Security;
using ChefBox.Security.Dto.User;
using ChefBox.Security.IData.Interfaces;
using ChefBox.SharedBoundedContext.Repositories;
using ChefBox.SqlServer.Database;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefBox.Security.Data.Repositories
{
    public class AccountRepository : ChefBoxRepository, IAccountRepository
    {
        public UserManager<CBUser> UserManager { get; }
        public SignInManager<CBUser> SignInManager { get; }
        public AccountRepository(ChefBoxDbContext context
            , UserManager<CBUser> userManager
            , SignInManager<CBUser> signInManager)
            : base(context)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }



        public async Task<UserInfoDto> Login(LoginDto loginDto)
        {
            if (!Context.Users.Any())
            {
                await CreateAccount(new UserInfoDto()
                {
                    Email = "chefBrown@chefBrown.com",
                    Password = "Aaa@123",
                    Username = "ChefBrown"
                });
            }
            var userEntity = Context.Users
                .SingleOrDefault(user => loginDto.UserName == user.UserName
                                ||
                                user.Email.ToUpper() == loginDto.UserName.ToUpper());
            if (userEntity == null)
            {
                return null;
            }
            var loginResult = await SignInManager.PasswordSignInAsync(userEntity, loginDto.Password, loginDto.RememberMe, false);
            if (loginResult == SignInResult.Success)
            {
                return new UserInfoDto()
                {
                    Id = userEntity.Id,
                    Username = userEntity.UserName,
                    Email = userEntity.Email
                };
            }
            return null;
        }

        public async Task<UserInfoDto> CreateAccount(UserInfoDto userInfoDto)
        {
            try
            {
                var result = await UserManager.CreateAsync(new CBUser()
                {
                    UserName = "ChefBrown",
                    Email = userInfoDto.Email,
                    EmailConfirmed = true
                }, userInfoDto.Password);
                if (result == IdentityResult.Success)
                {
                    return userInfoDto;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task Logout()
        {
            await SignInManager.SignOutAsync();
        }
    }
}
