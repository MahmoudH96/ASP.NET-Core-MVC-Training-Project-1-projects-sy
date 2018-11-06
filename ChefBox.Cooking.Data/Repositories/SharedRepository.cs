using ChefBox.Cooking.Data.Base;
using ChefBox.Cooking.Dto.Shared;
using ChefBox.Cooking.IData.Interfaces;
using ChefBox.SqlServer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChefBox.Cooking.Data.Repositories
{
    public class SharedRepository : ChefBoxRepository, ISharedRepository
    {
        public SharedRepository(ChefBoxDbContext context) : base(context)
        {
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
