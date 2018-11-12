using ChefBox.Cooking.Data.Base;
using ChefBox.Cooking.Dto.Shared;
using ChefBox.Cooking.IData.Interfaces;
using ChefBox.SqlServer.Database;
using System.Linq;

namespace ChefBox.Cooking.Data.Repositories
{
    public class SharedRepository : ChefBoxRepository, ISharedRepository
    {
        public SharedRepository(ChefBoxDbContext context) : base(context)
        {
        }

        public HomePageDto GetHomePageContent()
        {
            var latestCategory = Context.Categories
                .OrderBy(cat => cat.CreationDate)
                .FirstOrDefault();
            var latestIngredient = Context.Ingredients
               .OrderBy(ing => ing.CreationDate)
               .FirstOrDefault();
            var latestRecipe = Context.Recipes
               .OrderBy(rec => rec.CreationDate)
               .FirstOrDefault();
            return new HomePageDto()
            {
                Recipes = new CardDto()
                {
                    LatestItemId = latestRecipe == null ? 0 : latestRecipe.Id,
                    LatestItemName = latestRecipe == null ? string.Empty : latestRecipe.Name,
                    TotalCount = Context.Recipes.Count(rec => rec.IsValid)
                },
                Ingredients = new CardDto()
                {
                    LatestItemId = latestIngredient == null ? 0 : latestIngredient.Id,
                    LatestItemName = latestIngredient == null ? string.Empty : latestIngredient.Name,
                    TotalCount = Context.Ingredients.Count(ing => ing.IsValid)
                },
                Categories = new CardDto()
                {
                    LatestItemId = latestCategory == null ? 0 : latestCategory.Id,
                    LatestItemName = latestCategory == null ? string.Empty : latestCategory.Name,
                    TotalCount = Context.Categories.Count(cat => cat.IsValid)
                }
            };
        }

        public SharedContentDto GetSharedContent()
        {
            return new SharedContentDto()
            {
                RecipesCount = Context.Recipes.Count(recipe => recipe.IsValid),
                CategoriesCount = Context.Categories.Count(cat => cat.IsValid),
                IngredientsCount = Context.Ingredients.Count(ing => ing.IsValid),
            };
        }
    }
}
