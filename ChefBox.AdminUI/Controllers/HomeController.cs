using ChefBox.Cooking.IData.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChefBox.AdminUI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IIngredientRepository ingredientRepository)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
