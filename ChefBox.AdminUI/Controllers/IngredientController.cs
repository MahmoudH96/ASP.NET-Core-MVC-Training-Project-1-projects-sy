using ChefBox.AdminUI.ViewModels.Ingredient;
using ChefBox.Cooking.Dto.Ingredient;
using ChefBox.Cooking.IData.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChefBox.AdminUI.Controllers
{
    public class IngredientController : Controller
    {

        public IIngredientRepository IngredientRepository { get; }
        public IngredientController(IIngredientRepository ingredientRepository)
        {
            IngredientRepository = ingredientRepository;
        }


        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                Ingredients = IngredientRepository.GetIngredients(null)
            };
            return View(viewModel);
        }


        public IActionResult IngredientForm()
        {
            var vm = new IngredientFormViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult IngredientForm(IngredientFormViewModel ingredientFormViewModel)
        {
            var data = IngredientRepository.ActionIngredient(new IngredientDto()
            {
                Id = ingredientFormViewModel.Id,
                Name = ingredientFormViewModel.Name,
                Description = ingredientFormViewModel.Description
            });
            if (data != null)
            {
                return RedirectToAction(nameof(IngredientController.Index));
            }
            return Content("Failed");
        }
    }
}
