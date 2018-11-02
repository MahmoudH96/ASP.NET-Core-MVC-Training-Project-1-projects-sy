using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChefBox.AdminUI.ViewModels.Recipe;
using ChefBox.Cooking.IData.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChefBox.AdminUI.Controllers
{
    public class RecipeController : Controller
    {
        public IRecipeRepository RecipeRepository { get; }
        public RecipeController(IRecipeRepository recipeRepository)
        {
            RecipeRepository = recipeRepository;
        }


        public IActionResult Index()
        {
            var vm = new IndexViewModel()
            {
            };
            return View(vm);
        }


        [HttpGet]
        public IActionResult RecipeForm()
        {
            var vm = new RecipeFormViewModel()
            {
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult RecipeForm(RecipeFormViewModel recipeFormViewModel)
        {
            return null;
        }
    }
}
