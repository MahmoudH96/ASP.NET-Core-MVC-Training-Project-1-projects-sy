using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChefBox.AdminUI.ViewModels.Account
{
    /// <summary>
    /// The LoginViewModel class.
    /// </summary>
    public class LoginViewModel
    {
        #region Properties
        [Required(ErrorMessage = "Please enter the username/email")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter the password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        #endregion

        #region Constructors

        #endregion

        #region Methods

        #endregion
    }
}