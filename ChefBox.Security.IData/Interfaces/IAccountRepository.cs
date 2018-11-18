using ChefBox.Security.Dto.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChefBox.Security.IData.Interfaces
{
    public interface IAccountRepository
    {
        Task<UserInfoDto> Login(LoginDto loginDto);
        Task<UserInfoDto> CreateAccount(UserInfoDto userInfoDto);
        Task Logout();
    }
}
