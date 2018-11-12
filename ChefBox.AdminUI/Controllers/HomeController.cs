using ChefBox.AdminUI.Dto;
using ChefBox.AdminUI.ViewModels.Home;
using ChefBox.Cooking.IData.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace ChefBox.AdminUI.Controllers
{
    public class HomeController : ChefBoxController
    {
        public HomeController(IIngredientRepository ingredientRepository
            , ISharedRepository sharedRepository)
            : base(sharedRepository)
        {

        }
        public IActionResult Index()
        {
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
    }
}
