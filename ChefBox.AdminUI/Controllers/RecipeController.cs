using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChefBox.AdminUI.ViewModels.Recipe;
using ChefBox.Cooking.Dto.Photo;
using ChefBox.Cooking.Dto.Recipe;
using ChefBox.Cooking.IData.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChefBox.AdminUI.Controllers
{
    public class RecipeController : ChefBoxController
    {
        private const string RecipeImagesFolder = "recipeImages";
        public IRecipeRepository RecipeRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IHostingEnvironment HostingEnvironment { get; }
        public RecipeController(IRecipeRepository recipeRepository
            , ICategoryRepository categoryRepository
            , IHostingEnvironment hostingEnvironment
            , ISharedRepository sharedRepository)
            : base(sharedRepository)
        {
            RecipeRepository = recipeRepository;
            CategoryRepository = categoryRepository;
            HostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index()
        {
            var vm = new IndexViewModel()
            {
                Recipes = RecipeRepository.GetRecipes()
            };
            return View(vm);
        }

        public IActionResult View(int id)
        {
            var vm = new ViewRecipeViewModel()
            {
                ViewRecipeDto = RecipeRepository.GetRecipe(id)
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult RecipeForm()
        {
            var vm = new RecipeFormViewModel()
            {
                Categories = CategoryRepository.GetCategories()
                .Select(catDto => new SelectListItem()
                {
                    Value = catDto.Id.ToString(),
                    Text = catDto.Name
                }),
                RecipeIngredients = RecipeRepository.GetRecipeAllIngredients(0)
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult RecipeForm(RecipeFormViewModel recipeFormViewModel)
        {
            try
            {
                var wwwrootPath = HostingEnvironment.WebRootPath;
                var recipeImagesFolderPath = Path.Combine(wwwrootPath, RecipeImagesFolder);
                string photoNameOnHard = string.Empty;
                string fullPhotoPath = string.Empty;
                List<PhotoDto> photosDtos = new List<PhotoDto>();
                if (recipeFormViewModel.Photos != null)
                {
                    foreach (var photo in recipeFormViewModel.Photos)
                    {
                        photoNameOnHard = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                        fullPhotoPath = Path.Combine(recipeImagesFolderPath, photoNameOnHard);
                        using (var fileStream = new FileStream(fullPhotoPath, FileMode.Create))
                        {
                            photo.CopyTo(fileStream);
                            photosDtos.Add(new PhotoDto()
                            {
                                Name = photo.Name,
                                Url = $"/{RecipeImagesFolder}/{photoNameOnHard}"
                            });
                        }
                    }
                }
                var result = RecipeRepository.ActionRecipeForm(new RecipeFormDto()
                {
                    Id = recipeFormViewModel.Id,
                    Name = recipeFormViewModel.Name,
                    CategoryId = recipeFormViewModel.CategoryId,
                    RecipeType = recipeFormViewModel.RecipeType,
                    RecipeIngredients = recipeFormViewModel.RecipeIngredients,
                    Description = recipeFormViewModel.Description,
                    Photos = photosDtos,
                    IsPublished = recipeFormViewModel.IsPublished
                });
                if (result == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("View", "Recipe");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
