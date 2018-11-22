using ChefBox.AdminUI.Dto;
using ChefBox.AdminUI.ViewModels.Home;
using ChefBox.Cooking.IData.Interfaces;
using ChefBox.Logging.IService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace ChefBox.AdminUI.Controllers
{
    [Authorize]
    public class HomeController : ChefBoxController
    {
        public ILogService LogService { get; }
        public HomeController(IIngredientRepository ingredientRepository
            , ISharedRepository sharedRepository
            , ILogService logService)
            : base(sharedRepository)
        {
            LogService = logService;
        }
        public IActionResult Index()
        {
            throw new Exception("Test error case");
            var vm = new IndexViewModel()
            {
                HomePageDto = SharedRepository.GetHomePageContent()
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult GetHomeData()
        {
            Thread.Sleep(5000);
            var statistics = SharedRepository.GetSharedContent();
            var homeData = new HomeDataDto()
            {
                CategoriesCount = statistics.CategoriesCount,
                IngredientsCount = statistics.IngredientsCount,
                RecipesCount = statistics.RecipesCount
            };
            return Json(homeData);
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            // Get the details of the exception that occurred
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                string routeWhereExceptionOccurred = exceptionFeature.Path;
                Exception exceptionThatOccurred = exceptionFeature.Error;
                LogService.LogHttpError(new Logging.Dto.Errors.HttpErrorDto()
                {
                    Source = routeWhereExceptionOccurred,
                    Exception = exceptionThatOccurred
                });
            }
            return View();
        }
    }
}
