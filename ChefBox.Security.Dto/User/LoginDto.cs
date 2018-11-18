using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Security.Dto.User
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
