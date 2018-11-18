using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChefBox.AdminUI.Extensions;
using ChefBox.AdminUI.ViewModels.Account;
using ChefBox.Security.IData.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChefBox.AdminUI.Controllers
{
    /// <summary>
    /// The AccountController controller.
    /// </summary>
    [Authorize]
    public class AccountController : ChefBoxController
    {
        #region Properties
        public IAccountRepository AccountRepository { get; }

        #endregion

        #region Constructors
        public AccountController(IAccountRepository accountRepository)
        {
            AccountRepository = accountRepository;
        }
        #endregion

        #region Methods

        #region Routes
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var vm = new LoginViewModel();
            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var loginResult = await AccountRepository.Login(new Security.Dto.User.LoginDto()
            {
                UserName = loginViewModel.UserName,
                Password = loginViewModel.Password,
                RememberMe = loginViewModel.RememberMe
            });
            if (loginResult == null)
            {
                ModelState.AddModelError(string.Empty, "Wrong username or password");
                return View(loginViewModel);
            }
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).ToActionName());
        }

        public async Task<IActionResult> Logout()
        {
            await AccountRepository.Logout();
            return RedirectToAction(nameof(AccountController.Login));
        }
        #endregion

        #region Helpers
        #endregion

        #endregion
    }
}