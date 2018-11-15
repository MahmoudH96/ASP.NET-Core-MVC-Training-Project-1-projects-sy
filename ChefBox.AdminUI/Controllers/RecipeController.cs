using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChefBox.AdminUI.ViewModels.Recipe;
using ChefBox.Cooking.Dto.Photo;
using ChefBox.Cooking.Dto.Recipe;
using ChefBox.Cooking.IData.Interfaces;
using ChefBox.Model.Cooking.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

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


        public IActionResult Index(int?pageNumber,string query,int?categoryId,RecipeType? recipeType)
        {
           // var pageIndex = (pageNumber == null ? 1 : pageNumber)-1;
           var pageIndex = (pageNumber ?? 1) - 1;
           var pageSize = 1;
            var pageDataResult = RecipeRepository.GetRecipes(new FilterCriteria()
            {
                PageSize= pageSize,
                PageNumber=pageIndex,
                Query=query,
                CategoryId=categoryId,
                RecipeType=recipeType
            });
            var vm = new IndexViewModel()
            {
                SinglePageData= pageDataResult.PageData,
                PageListData = new StaticPagedList<RecipeDto>(pageDataResult.PageData, pageIndex + 1, pageSize, pageDataResult.TotalResultCount),
                Categories= CategoryRepository.GetCategories()
                .Select(cat=>new SelectListItem(cat.Name,cat.Id.ToString())),
                Query=query,
                RecipeType= recipeType,
                CategoryId=categoryId
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
        public IActionResult RecipeForm(int? id)
        {
            return View(GetRecipeFormData(id, null));
        }

        public RecipeFormViewModel GetRecipeFormData(int? id, RecipeFormViewModel vm)
        {
            if (vm == null)
            {
                vm = new RecipeFormViewModel()
                {
                    RecipeIngredients = RecipeRepository.GetRecipeAllIngredients(id ?? 0)
                };

            }
            if (id.HasValue)
            {
                var recipeData = RecipeRepository.GetRecipe(id.Value);
                vm.CategoryId = recipeData.CategoryId;
                vm.Description = recipeData.Description;
                vm.IsPublished = recipeData.IsPublished;
                vm.Name = recipeData.Name;
                vm.RecipeType = recipeData.RecipeType;
            }
            vm.Categories = CategoryRepository.GetCategories()
                       .Select(catDto => new SelectListItem()
                       {
                           Value = catDto.Id.ToString(),
                           Text = catDto.Name
                       });
            return vm;
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
                return RedirectToAction("View", "Recipe", new { id = result.Id });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
