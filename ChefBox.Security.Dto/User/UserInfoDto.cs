using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Security.Dto.User
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
