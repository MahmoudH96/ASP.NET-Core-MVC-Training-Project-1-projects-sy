using ChefBox.Cooking.IData.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
    }
}
